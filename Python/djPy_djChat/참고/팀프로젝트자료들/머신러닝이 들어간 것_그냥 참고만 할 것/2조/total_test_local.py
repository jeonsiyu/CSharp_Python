#print("메시지 입력")
#query = input()  # "오늘 탕수육 주문 가능한가요?"
from utils.Preprocess import Preprocess
from models.intent.IntentModel import IntentModel
from models.ner.NerModel import NerModel

import urllib.request
from urllib import parse
import json

import random

p = Preprocess(word2index_dic='./train_tools/dict/chatbot_dict.bin',
               userdic='./utils/user_dic.tsv')

intent = IntentModel(model_name='./models/intent/intent_model.h5', preprocess=p)
ner = NerModel(model_name='./models/ner/ner_model.h5', preprocess=p)
while True:
    print("배고픈 당신, 떠오르는 말을 적어 보세요.")
    query = input()#"오늘 탕수육 주문 가능한가요?"
    predict = intent.predict_class(query)
    predict_label = intent.labels[predict]
    predicts = ner.predict(query)
    tags = ner.predict_tags(query)
    print(query)
    #print(predicts)
    #print(tags)
    #print(predicts[0][1])
    #print("의도 예측 클래스 : ", predict)
    #print("의도 예측 레이블 : ", predict_label)
    #{0: "인사", 1: "욕설", 2: "주문", 3: "예약", 4: "기타"}
    if predict_label=="인사":
        print("반갑습니다.")
    elif predict_label=="욕설":
        print("미쳤습니까 휴먼?")
    elif predict_label=="주문" or predict_label=="예약":
        food_name = ""
        for item in predicts:
            if item[1] == 'B_FOOD': #음식에 해당하는 내용이 있는 경우
                food_name=item[0]
                #food_name=''
                break
        
        local_list=["동구","수성구","북구","서구","중구","남구","달서구","달성군"]
        restaurant_list = []
        for item in local_list:
            #print(item)
            local = parse.quote(item)
            url = 'https://www.daegufood.go.kr/kor/api/tasty.html?mode=json&addr=%s' % local
            response = urllib.request.urlopen(url)
            response_message = response.read().decode('utf8')
            data = json.loads(response_message, strict=False)
            json_arr = data['data']
            restaurant_list = restaurant_list + json_arr
        myrestaurant_list = []
        if food_name != "":
            myrestaurant_list = list(filter(lambda n: food_name in n['MNU'], restaurant_list))

        if len(myrestaurant_list)==0:
            print("그건 없네요. 아무거나 드셔 보세요.")
            myrestaurant_list = restaurant_list
        #print(restaurant_list)
        #print(local)
        #print(restaurant_list)
        myrestaurant = random.choice(myrestaurant_list)
        #print(len(restaurant_list)) #1019 , 35



        print(myrestaurant['GNG_CS'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['FD_CS'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['BZ_NM'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['TLNO'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['MBZ_HR'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['SEAT_CNT'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['MNU'].replace('<br','').replace(' />','\n'))
        #mymenus = str((myrestaurant['MNU']))
        #mymenus = mymenus.replace('<br','')
        #mymenus = mymenus.replace(' />','\n')
        #mymenus = myrestaurant['MNU'].replace('<br />','\n')
        #print(mymenus)
        print(myrestaurant['SMPL_DESC'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['SBW'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['BUS'].replace('<br','').replace(' />','\n'))
        print(myrestaurant['BKN_YN'].replace('<br','').replace(' />','\n'))
        '''
        
        cnt: 순번
        OPENDATA_ID : 고유 번호
        GNG_CS : 주소
        FD_CS : 음식카테고리
        BZ_NM : 음식점명
        TLNO : 연락처
        MBZ_HR : 영업시간
        SEAT_CNT : 좌석수
        PKPL : 주차장
        HP : 웹사이트
        PSB_FRN : 가능언어
        BKN_YN : 예약가능여부
        INFN_FCL : 놀이시설여부
        BRFT_YN : 조식여부
        DSSRT_YN : 후식여부
        MNU : 메뉴
        SMPL_DESC : 설명
        SBW : 지하철 오시는길
        BUS : 버스 오시는길
        '''


        #print(response_message)



        #hospitals = []
        #print("이 맛집을 추천합니다.")

    else:
        print("더 공부하겠습니다. 휴먼. 무슨 말인지 모르겠어요.")