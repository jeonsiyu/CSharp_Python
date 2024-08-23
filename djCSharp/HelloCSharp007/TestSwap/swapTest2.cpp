#include<iostream>
using namespace std;
void swap(int& x, int& y)
{
	int temp = x;
	x = y;
	y = temp;
}
int main()
{
	int a = 3;
	int b = 5;
	
	//참조자 : C++에선 &붙이고 C#에선 ref란 키워드를 붙임
	//참조자 : 변수에 저장된 값도 저장하고, 그 변수에 있는 위치도 같이 가지고 있음
	int& refa = a;
	int& refb = b;
	cout << refa << refb << endl;


	swap(a, b);
	cout << a << b << endl;
	swap(refa, refb);
	cout << a << b << endl;
	return 0;
}