#include "dllhook.h"
#include "atltypes.h"
#define OCR_NORMAL 32512

HHOOK hMouseHook; 
HHOOK hKeyboardHook; 
HINSTANCE hInst;


EXPORT void CALLBACK SetMouseHook(void)
{
	hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseProc, hInst, 0); 
}

EXPORT void CALLBACK UnMouseHook(void)
{
	UnhookWindowsHookEx(hMouseHook);
}

EXPORT void CALLBACK SetKeyBoardHook(void)
{
	hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardProc, hInst, 0); 
}

EXPORT void CALLBACK UnKeyBoardHook(void)
{
	UnhookWindowsHookEx(hKeyboardHook);
}

LRESULT CALLBACK KeyboardProc(int code, WPARAM wParam, LPARAM lParam)
{
	if ( code<0 )
	{
		CallNextHookEx(hKeyboardHook, code, wParam, lParam);
        return 0;
	}

	if (wParam == WM_KEYDOWN) 
	{
		PKBDLLHOOKSTRUCT p = (PKBDLLHOOKSTRUCT) (lParam);
		
		if(p->vkCode == VK_SPACE) 
		{

			/* Запускает программу Fraps нажатием на пробел */
			WinExec("D:\\Fraps\\fraps.exe", 1);

		}
     
		return CallNextHookEx(NULL, code, wParam, lParam);
	}
}
LRESULT CALLBACK MouseProc(int code, WPARAM wParam, LPARAM lParam)
{
	if (code < 0)
	{
		CallNextHookEx(hMouseHook, code, wParam, lParam);
		return 0;
	}
	HCURSOR hc = LoadCursor(NULL, IDC_WAIT);
	if (wParam == WM_MBUTTONDOWN)
	{
		SetSystemCursor(hc, OCR_NORMAL);
		return 0;
	}
	if (wParam == WM_RBUTTONDOWN)
	{
		ShowCursor(false);
		return 0;
	}
	if (wParam == WM_LBUTTONDOWN)
	{
		ShowCursor(true);
		return 0;
	}
	return CallNextHookEx(NULL, code, wParam, lParam);

}


BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	hInst = hinstDLL;
	return TRUE;
}
