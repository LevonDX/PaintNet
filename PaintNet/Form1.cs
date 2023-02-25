namespace PaintNet
{
    public partial class Form1 : Form
    {
        Graphics graphics;

        Pen pen = new Pen(Color.Black, 5);

        bool isDown = false;
        int counter = 0;

        List<List<Point>> lines = new List<List<Point>>();
        List<Point> currentLine = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            this.DoubleBuffered = true;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;

            this.Paint += Form1_Paint;

            graphics = this.CreateGraphics();
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            for (int i = 0; i < this.currentLine.Count - 1; i++)
            {
                e.Graphics.DrawLine(pen, currentLine[i], currentLine[i + 1]);
            }

            foreach (var item in this.lines)
            {
                List<Point> points = item;
                for (int i = 0; i < points.Count - 1; i++)
                {
                    e.Graphics.DrawLine(pen, points[i], points[i + 1]);
                }
            }
        }

        private void Form1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDown)
            {
                counter++;

                currentLine.Add(e.Location);
                
                //if (counter % 5 == 0)
                    Invalidate();
            }
        }

        private void Form1_MouseUp(object? sender, MouseEventArgs e)
        {
            this.lines.Add(currentLine);
            currentLine = new List<Point>();

            isDown = false;
        }

        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            isDown = true;
            currentLine.Add(e.Location);
        }
    }
}