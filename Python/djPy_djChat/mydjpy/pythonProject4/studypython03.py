for item in range(1,11):
    print(item) #ctrl shift f10 눌러서 실행
#1부터 10까지 출력하는 코드
#range(a,b) : a부터 b-1까지의 값을 범위로 갖는 리스트를 만드는 함수
#즉 ragne(1,11)은 [1,2,3,4,5,6,7,8,9,10] 이런 형태의 리스트 만드는 함수
fColor = [('바나나','노란색'), ('포도','보라색'), ('딸기','빨간색')]
for item in fColor:
    print(item)
for a,b in fColor:
    print('과일 : ' + a + ' 색상 : ' + b)

def printName(name):
    print('이름 : ' + name)

def calcAbs(num):
    if num<0:
        num *= -1
    return num

printName('이동준')
print(calcAbs(-1))
print(calcAbs(10))