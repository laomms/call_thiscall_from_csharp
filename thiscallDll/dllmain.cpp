#include "pch.h"
#include "Windows.h"
#include <stdio.h>


class __declspec(dllexport) TestClass {

public:
	int __thiscall func_thiscall(int a,int b,int c,int d)
	{
		return a+b+c+d;
	}
};

