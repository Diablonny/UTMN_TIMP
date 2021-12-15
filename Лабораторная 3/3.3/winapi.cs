#include <windows.h>
#include <tchar.h>
#include <strsafe.h>
#include <iostream>
using namespace std;

DWORD WINAPI thread2(LPVOID);

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Первый поток\n";
	HANDLE thread = CreateThread(NULL, 0, thread2, NULL, 0, NULL);
	cout << "Что-то с первого потока\n";
	for (int i = 0; i < 1000000; i++)
	{	}
	cout << "Еще что-то с первого потока\n";
}

DWORD WINAPI thread2(LPVOID t)
{
	cout << "Второй поток\n";
}
