using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class frmExecutando : Form
	{
		Thread thread;

		[DllImport("user32.dll")]
		public static extern bool SetCursorPos(int x, int y);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint CButtons, uint dwExtraInfo);
		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFT_UP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;

		[DllImport("user32.dll")]
		public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

		[StructLayout(LayoutKind.Sequential)]
		public struct DEVMODE
		{
			private const int CCHDEVICENAME = 0x20;
			private const int CCHFORMNAME = 0x20;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
			public string dmDeviceName;
			public short dmSpecVersion;
			public short dmDriverVersion;
			public short dmSize;
			public short dmDriverExtra;
			public int dmFields;
			public int dmPositionX;
			public int dmPositionY;
			public ScreenOrientation dmDisplayOrientation;
			public int dmDisplayFixedOutput;
			public short dmColor;
			public short dmDuplex;
			public short dmYResolution;
			public short dmTTOption;
			public short dmCollate;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
			public string dmFormName;
			public short dmLogPixels;
			public int dmBitsPerPel;
			public int dmPelsWidth;
			public int dmPelsHeight;
			public int dmDisplayFlags;
			public int dmDisplayFrequency;
			public int dmICMMethod;
			public int dmICMIntent;
			public int dmMediaType;
			public int dmDitherType;
			public int dmReserved1;
			public int dmReserved2;
			public int dmPanningWidth;
			public int dmPanningHeight;
		}

		public new int Width { get; set; }

		public new int Height { get; set; }

		public frmExecutando()
		{
			InitializeComponent();
		}

		protected override void WndProc(ref Message message)
		{
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_MOVE = 0xF010;

			switch (message.Msg)
			{
				case WM_SYSCOMMAND:
					int command = message.WParam.ToInt32() & 0xfff0;
					if (command == SC_MOVE)
						return;
					break;
			}

			base.WndProc(ref message);
		}

		private void frm_Executando_Load(object sender, EventArgs e)
		{
			pctGif.Visible = false;
			CarregarConfDisplay();
		}

		public void SetCursorPosition(int x, int y)
		{
			Cursor.Position = this.PointToScreen(new Point(x, y));
			SetCursorPos(x, y);
		}

		public void DoMouseClick()
		{
			uint x = (uint)Cursor.Position.X;
			uint y = (uint)Cursor.Position.Y;
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFT_UP, x, y, 0, 0);
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			ThreadStart threadStart = new ThreadStart(Execution);
			thread = new Thread(threadStart);
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		private void Execution()
		{
			Random rdNum = new Random();

			while (true)
			{
				btnInicio.Invoke((MethodInvoker)delegate
				{
					this.Text = "App Move processando...";
					pctGif.Visible = true;
					btnInicio.Text = "Executando";
					btnInicio.Enabled = false;
					lblConfiguracao.Text = $"Config. Video: {Width} x {Height}";
					SetCursorPosition((Width / 2) + rdNum.Next(100), (Height / 2) + rdNum.Next(100));
					DoMouseClick();
				});

				Application.DoEvents();
				Thread.Sleep(10000);
			}
		}

		private void CarregarConfDisplay()
		{
			DEVMODE vDevMode = new DEVMODE();
			int i = 0;
			EnumDisplaySettings(null, i, ref vDevMode);
			Width = vDevMode.dmPelsWidth;
			Height = vDevMode.dmPelsHeight;
		}

		private void btnParar_Click(object sender, EventArgs e)
		{
			if (thread != null && (thread.ThreadState == ThreadState.Running ||
				thread.ThreadState == ThreadState.Background ||
				thread.ThreadState == ThreadState.WaitSleepJoin))
			{
				thread.Abort();
				pctGif.Visible = false;
				btnInicio.Enabled = true;
				this.Text = "App Move...";
				btnInicio.Text = "Início";
			}
			else
			{
				MessageBox.Show("O Processo não esta em execução.",
								"Informação Importante",
								MessageBoxButtons.OK,
								MessageBoxIcon.Information
								);
			}
		}
	}
}