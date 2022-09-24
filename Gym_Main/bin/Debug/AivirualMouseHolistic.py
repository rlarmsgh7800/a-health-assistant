import cv2
import mediapipe as mp
import numpy as np
import HolisticModule as htm
import time
import autopy
#import matplotlib.pyplot as plt
#from matplotlib.animation import FuncAnimation
#import pandas as pd
from itertools import count


############## Moving Averange ##########
raw_arrayx = []
raw_arrayy = []
raw_arrayz = []
MASK_LENGTH = 10

for i in range(MASK_LENGTH+1): # 0으로 초기화
    raw_arrayx.append(0)
    raw_arrayy.append(0)

##########################
wCam, hCam = 640, 480
frameR = 100 # Frame Reduction
smoothening = 3
#########################

Slop = 40 / 25

pTime = 0
plocX, plocY ,plocZ = 0, 0 ,0
clocX, clocY,clocZ = 0, 0 ,0

length = 0 #  Click distanc
DistanceBar = 450
z0 =0
Mouse_Click = False


# For webcam input:
cap = cv2.VideoCapture(0,cv2.CAP_DSHOW)
cap.set(3, wCam)
cap.set(4, hCam)
detector = htm.holistDetector()
wScr, hScr = autopy.screen.size()

def moving_averagex(value) :

    for i in range(MASK_LENGTH-1,0-1,-1):   # insertIntoRawArray
        raw_arrayx[i+1] = raw_arrayx[i]
    raw_arrayx[0] = value
    raw_arrayx[MASK_LENGTH] = 0

    #print(raw_arrayx)
    ret = np.cumsum(raw_arrayx, dtype=float)
    ret[MASK_LENGTH:] = ret[MASK_LENGTH:] - ret[:-MASK_LENGTH]
    resultx = ret[MASK_LENGTH - 1:] / MASK_LENGTH

    return resultx[0]

def moving_averagey(value) :

    for i in range(MASK_LENGTH-1,0-1,-1):   # insertIntoRawArray
        raw_arrayy[i+1] = raw_arrayy[i]
    raw_arrayy[0] = value
    raw_arrayy[MASK_LENGTH] = 0

    #print(raw_arrayy)
    ret = np.cumsum(raw_arrayy, dtype=float)
    ret[MASK_LENGTH:] = ret[MASK_LENGTH:] - ret[:-MASK_LENGTH]
    resulty = ret[MASK_LENGTH - 1:] / MASK_LENGTH

    return resulty[0]

# def moving_averagez(value) :

#     for i in range(MASK_LENGTH-1,0-1,-1):   # insertIntoRawArray
#         raw_arrayz[i+1] = raw_arrayz[i]
#     raw_arrayz[0] = value
#     raw_arrayz[MASK_LENGTH] = 0

#     #print(raw_arrayy)
#     ret = np.cumsum(raw_arrayz, dtype=float)
#     ret[MASK_LENGTH:] = ret[MASK_LENGTH:] - ret[:-MASK_LENGTH]
#     resultz = ret[MASK_LENGTH - 1:] / MASK_LENGTH

#     return resultz[0]

while cap.isOpened():
    # 1. Find hand Landmarks
    success, image = cap.read()
    image = detector.findHands(image)
    lmList, bbox = detector.findPosition(image)

    # #2. Get the tip of the index and fingers
    if len(lmList) != 0:
        x1, y1 = lmList[8][1:3] # 검지 끝
        x2, y2 = lmList[5][1:3] # 검지
        x3, y3 = lmList[4][1:3] # 엄지
        z0 = lmList[5][3] # Z

    fingers = detector.fingersUp()
    #print(fingers)
    cv2.rectangle(image, (frameR, frameR), (wCam - frameR, hCam - frameR),(255, 0, 255), 2)

    # z101 = moving_averagez(z0)
    # print(z101)
    # print(type(z101))

    try:# 4. Only Index Finger : Moving Mode
        if fingers[0] == 1 and fingers[1] == 1 and fingers[2] == 0 and fingers[3] == 0:
            # 5. Convert Coordinates
            x100 = np.interp(x1, (frameR, wCam - frameR), (0, wScr))
            y100 = np.interp(y1, (frameR, hCam - frameR), (0, hScr))


            x101 = moving_averagex(x100)
            y101 = moving_averagey(y100)

            # 6. Smoothen Values
            clocX = plocX + (x101 - plocX) / smoothening
            clocY = plocY + (y101 - plocY) / smoothening
            clocZ = plocZ + (z0 - plocZ) / smoothening

            # 7. Move Mouse
            autopy.mouse.move(wScr - clocX, clocY)
            cv2.circle(image, (x1, y1), 15, (255, 0, 255), cv2.FILLED)
            plocX, plocY,plocZ = clocX, clocY , clocZ

    except :
        pass

    try:# 8.  Clicking Mode
        if  fingers[1] == 1 and fingers[2] == 0 and fingers[3] == 0:
            # 9. Find distance between fingers
            length, image, lineInfo = detector.findDistance(4, 10, image)
            #print(type(length))

            length = length + (95-(13.5*clocZ+11.5))

            DistanceBar = np.interp(length, [5, 200], [450, 250])

            # 10. Click mouse if distance short
            if  Mouse_Click == False:
                cv2.circle(image, (lineInfo[4], lineInfo[5]),15, (0, 0, 255), cv2.FILLED)
            else:
                cv2.circle(image, (lineInfo[4], lineInfo[5]),15, (0, 255, 0), cv2.FILLED)


            if length > 80 +(95-(13.5*clocZ+11.5)) and Mouse_Click == True:
                Mouse_Click = False
            if length < 40+(95-(13.5*clocZ+11.5)) and Mouse_Click == False:
                Mouse_Click = True
                # cv2.circle(image, (lineInfo[4], lineInfo[5]),15, (0, 255, 0), cv2.FILLED)
                autopy.mouse.click()
    except :
        pass


    # 11. Frame Rate
    image = cv2.flip(image,1) # 좌우반전

    cTime = time.time()
    fps = 1 / (cTime - pTime)
    pTime = cTime



    cv2.putText(image, str(int(fps)), (20, 50), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # FPS
    cv2.putText(image, str(float(wScr)), (20, 80), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # screen width
    cv2.putText(image, str(float(hScr)), (150, 80), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # screen heigh
    cv2.putText(image, str(int(clocX)), (20, 110), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # Mouse Location x
    cv2.putText(image, str(int(clocY)), (150, 110), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # Mouse Location y
    cv2.putText(image, str(float(clocZ)), (250, 110), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # Mouse Location Z
    cv2.putText(image, str(list(fingers)), (20, 140), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # Finger_stand ?

    cv2.rectangle(image, (20, 250), (55, 450), (255, 0, 0), 3)
    cv2.rectangle(image, (20, int(DistanceBar)), (55, 450), (255, 0, 0), cv2.FILLED)
    cv2.putText(image, str(bool(Mouse_Click)), (70, 420), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # Bool Mouse
    cv2.putText(image, str(float(length)), (70, 450), cv2.FONT_HERSHEY_PLAIN, 2,(255, 0, 0), 2) # Distance


    cv2.imshow('MediaPipe Holistic', image)
    if cv2.waitKey(5) & 0xFF == 27:
        break
cap.release()
