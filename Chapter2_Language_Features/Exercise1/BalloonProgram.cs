using System;
using System.Diagnostics;
using System.Drawing;

namespace Exercise1
{
    public class BalloonProgram
    {
        private WriteDelegate writeDelegate;
        private readonly Random random = new Random();

        private Balloon[] balloons = new Balloon[5];

        public BalloonProgram(WriteDelegate writeDelegate) {
            this.writeDelegate = writeDelegate;
            this.writeDelegate = Console.WriteLine;
            this.writeDelegate += (string message) => { Debug.WriteLine(message.ToUpper()); };
        }

        public void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                balloons[i] = random.NextBalloon(100);
                writeDelegate("balloon of size " + balloons[i].Size.ToString() + " and color Color " + balloons[i].Color.ToString());
            }
            Balloon toPop = random.NextBalloonFromArray(balloons);
            writeDelegate("popped balloon of size " + toPop.Size.ToString() + " and color Color " + toPop.Color.ToString());

        }
    }
}