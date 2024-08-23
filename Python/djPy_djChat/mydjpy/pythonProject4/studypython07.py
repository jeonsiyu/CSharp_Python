from konlpy.tag import Komoran
k = Komoran() # 생성자 이용해서 객체 만들었음
text1 = '아버지가 방에 들어갑니다.'
print(k.morphs(text1)) #형태소 단위로 짤라서 출력
print(k.nouns(text1))  #명사들만 짤라서 출력
text1 = '아버지가방에 들어갑니다.'
print(k.morphs(text1)) #형태소 단위로 짤라서 출력
print(k.nouns(text1))  #명사들만 짤라서 출력