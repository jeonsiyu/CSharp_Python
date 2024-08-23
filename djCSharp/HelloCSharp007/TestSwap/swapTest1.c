#include<stdio.h>
void swap(int* x, int* y)
{
	int temp = *x;
	*x = *y;
	*y = temp;
}
int main()
{
	int a = 3;
	int b = 5;
	//printf("%lld %lld", &a, &b);
	swap(&a, &b);
	return 0;
}