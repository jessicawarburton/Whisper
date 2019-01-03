﻿namespace Whisper.Apps.Desktop.Controls.Helpers
{
    public static class WindowMessages
    {
        // Source: https://autohotkey.com/docs/misc/SendMessageList.htm

        public const int Null = 0x00;
        public const int Create = 0x01;
        public const int Destroy = 0x02;
        public const int Move = 0x03;
        public const int Size = 0x05;
        public const int Activate = 0x06;
        public const int SetFocus = 0x07;
        public const int KillFocus = 0x08;
        public const int Enable = 0x0A;
        public const int SetRedraw = 0x0B;
        public const int SetText = 0x0C;
        public const int GetText = 0x0D;
        public const int GetTextLength = 0x0E;
        public const int Paint = 0x0F;
        public const int Close = 0x10;
        public const int QueryEndSession = 0x11;
        public const int Quit = 0x12;
        public const int QueryOpen = 0x13;
        public const int EraseBkgnd = 0x14;
        public const int SysColorChange = 0x15;
        public const int EndSession = 0x16;
        public const int SystemError = 0x17;
        public const int ShowWindow = 0x18;
        public const int CtlColor = 0x19;
        public const int WinIniChange = 0x1A;
        public const int SettingChange = 0x1A;
        public const int DevModeChange = 0x1B;
        public const int ActivateApp = 0x1C;
        public const int FontChange = 0x1D;
        public const int TimeChange = 0x1E;
        public const int CancelMode = 0x1F;
        public const int SetCursor = 0x20;
        public const int MouseActivate = 0x21;
        public const int ChildActivate = 0x22;
        public const int QueueSync = 0x23;
        public const int GetMinMaxInfo = 0x24;
        public const int PaintIcon = 0x26;
        public const int IconEraseBkgnd = 0x27;
        public const int NextDlgCtl = 0x28;
        public const int SpoolerStatus = 0x2A;
        public const int DrawItem = 0x2B;
        public const int MeasureItem = 0x2C;
        public const int DeleteItem = 0x2D;
        public const int VKeyToItem = 0x2E;
        public const int CharToItem = 0x2F;
        public const int SetFont = 0x30;
        public const int GetFont = 0x31;
        public const int SetHotKey = 0x32;
        public const int GetHotKey = 0x33;
        public const int Querydragicon = 0x37;
        public const int CompareItem = 0x39;
        public const int Compacting = 0x41;
        public const int WindowPosChanging = 0x46;
        public const int WindowPosChanged = 0x47;
        public const int Power = 0x48;
        public const int CopyData = 0x4A;
        public const int CancelJournal = 0x4B;
        public const int Notify = 0x4E;
        public const int InputLangChangeRequest = 0x50;
        public const int InputLangChange = 0x51;
        public const int TCard = 0x52;
        public const int Help = 0x53;
        public const int Userchanged = 0x54;
        public const int NotifyFormat = 0x55;
        public const int ContextMenu = 0x7B;
        public const int StyleChanging = 0x7C;
        public const int StyleChanged = 0x7D;
        public const int DisplayChange = 0x7E;
        public const int GetIcon = 0x7F;
        public const int SetIcon = 0x80;
        public const int NcCreate = 0x81;
        public const int NcDestroy = 0x82;
        public const int NcCalcSize = 0x83;
        public const int NcHitTest = 0x84;
        public const int NcPaint = 0x85;
        public const int NcActivate = 0x86;
        public const int GetDlgCode = 0x87;
        public const int NcMouseMove = 0xA0;
        public const int NclButtonDown = 0xA1;
        public const int NclButtonUp = 0xA2;
        public const int NclButtonDblClk = 0xA3;
        public const int NcrButtonDown = 0xA4;
        public const int NcrButtonUp = 0xA5;
        public const int NcrButtonDblClk = 0xA6;
        public const int NcmButtonDown = 0xA7;
        public const int NcmButtonUp = 0xA8;
        public const int NcmButtonDblClk = 0xA9;
        public const int KeyFirst = 0x100;
        public const int KeyDown = 0x100;
        public const int KeyUp = 0x101;
        public const int Char = 0x102;
        public const int Deadchar = 0x103;
        public const int Syskeydown = 0x104;
        public const int Syskeyup = 0x105;
        public const int Syschar = 0x106;
        public const int Sysdeadchar = 0x107;
        public const int Keylast = 0x108;
        public const int ImeStartcomposition = 0x10D;
        public const int ImeEndcomposition = 0x10E;
        public const int ImeComposition = 0x10F;
        public const int ImeKeylast = 0x10F;
        public const int Initdialog = 0x110;
        public const int Command = 0x111;
        public const int Syscommand = 0x112;
        public const int Timer = 0x113;
        public const int Hscroll = 0x114;
        public const int Vscroll = 0x115;
        public const int Initmenu = 0x116;
        public const int Initmenupopup = 0x117;
        public const int Menuselect = 0x11F;
        public const int Menuchar = 0x120;
        public const int Enteridle = 0x121;
        public const int Ctlcolormsgbox = 0x132;
        public const int Ctlcoloredit = 0x133;
        public const int Ctlcolorlistbox = 0x134;
        public const int Ctlcolorbtn = 0x135;
        public const int Ctlcolordlg = 0x136;
        public const int Ctlcolorscrollbar = 0x137;
        public const int Ctlcolorstatic = 0x138;
        public const int Mousefirst = 0x200;
        public const int Mousemove = 0x200;
        public const int Lbuttondown = 0x201;
        public const int Lbuttonup = 0x202;
        public const int Lbuttondblclk = 0x203;
        public const int Rbuttondown = 0x204;
        public const int Rbuttonup = 0x205;
        public const int Rbuttondblclk = 0x206;
        public const int Mbuttondown = 0x207;
        public const int Mbuttonup = 0x208;
        public const int Mbuttondblclk = 0x209;
        public const int Mousewheel = 0x20A;
        public const int Mousehwheel = 0x20E;
        public const int Parentnotify = 0x210;
        public const int Entermenuloop = 0x211;
        public const int Exitmenuloop = 0x212;
        public const int Nextmenu = 0x213;
        public const int Sizing = 0x214;
        public const int Capturechanged = 0x215;
        public const int Moving = 0x216;
        public const int Powerbroadcast = 0x218;
        public const int Devicechange = 0x219;
        public const int Mdicreate = 0x220;
        public const int Mdidestroy = 0x221;
        public const int Mdiactivate = 0x222;
        public const int Mdirestore = 0x223;
        public const int Mdinext = 0x224;
        public const int Mdimaximize = 0x225;
        public const int Mditile = 0x226;
        public const int Mdicascade = 0x227;
        public const int Mdiiconarrange = 0x228;
        public const int Mdigetactive = 0x229;
        public const int Mdisetmenu = 0x230;
        public const int Entersizemove = 0x231;
        public const int Exitsizemove = 0x232;
        public const int Dropfiles = 0x233;
        public const int Mdirefreshmenu = 0x234;
        public const int ImeSetcontext = 0x281;
        public const int ImeNotify = 0x282;
        public const int ImeControl = 0x283;
        public const int ImeCompositionfull = 0x284;
        public const int ImeSelect = 0x285;
        public const int ImeChar = 0x286;
        public const int ImeKeydown = 0x290;
        public const int ImeKeyup = 0x291;
        public const int Mousehover = 0x2A1;
        public const int Ncmouseleave = 0x2A2;
        public const int Mouseleave = 0x2A3;
        public const int Cut = 0x300;
        public const int Copy = 0x301;
        public const int Paste = 0x302;
        public const int Clear = 0x303;
        public const int Undo = 0x304;
        public const int Renderformat = 0x305;
        public const int Renderallformats = 0x306;
        public const int Destroyclipboard = 0x307;
        public const int Drawclipboard = 0x308;
        public const int Paintclipboard = 0x309;
        public const int Vscrollclipboard = 0x30A;
        public const int Sizeclipboard = 0x30B;
        public const int Askcbformatname = 0x30C;
        public const int Changecbchain = 0x30D;
        public const int Hscrollclipboard = 0x30E;
        public const int Querynewpalette = 0x30F;
        public const int Paletteischanging = 0x310;
        public const int Palettechanged = 0x311;
        public const int Hotkey = 0x312;
        public const int Print = 0x317;
        public const int Printclient = 0x318;
        public const int Handheldfirst = 0x358;
        public const int Handheldlast = 0x35F;
        public const int Penwinfirst = 0x380;
        public const int Penwinlast = 0x38F;
        public const int CoalesceFirst = 0x390;
        public const int CoalesceLast = 0x39F;
        public const int DdeFirst = 0x3E0;
        public const int DdeInitiate = 0x3E0;
        public const int DdeTerminate = 0x3E1;
        public const int DdeAdvise = 0x3E2;
        public const int DdeUnadvise = 0x3E3;
        public const int DdeAck = 0x3E4;
        public const int DdeData = 0x3E5;
        public const int DdeRequest = 0x3E6;
        public const int DdePoke = 0x3E7;
        public const int DdeExecute = 0x3E8;
        public const int DdeLast = 0x3E8;
        public const int User = 0x400;
        public const int App = 0x8000;
    }
}
