using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace kruidendop
{
	class Program
	{


		static float DrawString(Graphics g, string s, StringFormat format, float y, float maxSize)
		{
			Font font = null;
			float fsize;
			for (fsize = maxSize; fsize > 1; fsize -= 0.01f)
			{
				font = new System.Drawing.Font("Roboto", fsize, FontStyle.Bold);
				var size = g.MeasureString(s, font, 0, format);
				if (size.Width < 84)
					break;
			}

			float middle = g.VisibleClipBounds.Width / 2;
			g.DrawString(s, font, Brushes.Black, middle, y, format);
			return fsize;
		}


		static void Main(string[] args)
		{

			Console.Write("name    : ");
			string line1 = Console.ReadLine();
			Console.Write("extra 1 : ");
			string line2 = Console.ReadLine();
			Console.Write("extra 2 : ");
			string line3 = Console.ReadLine();



			PrintPreviewDialog dialog = new PrintPreviewDialog();
			PrintDocument pd = new PrintDocument();
			pd.PrinterSettings.PrinterName = "Brother QL-700";

			Margins m = new Margins(0, 0, 0, 0);
			pd.DefaultPageSettings.Margins = m;
			pd.OriginAtMargins = false;
			var ps = pd.DefaultPageSettings;

			var a = ps.PrintableArea;

			pd.PrintPage += (object s, PrintPageEventArgs ev) =>
			{

				float middle = ev.Graphics.VisibleClipBounds.Width / 2;

				var format = new StringFormat();
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Far;

				var size = DrawString(ev.Graphics, line1, format, middle, 16);
				format.LineAlignment = StringAlignment.Near;
				DrawString(ev.Graphics, line2 + "\n" + line3, format, middle, size - 2);

				ev.HasMorePages = false;
			};
#if true
			pd.Print();
#else
            dialog.Document = pd;
            dialog.ShowDialog();
#endif
		}
	}
}
