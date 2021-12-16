using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        
        static Scorer scorer;
        static List<Frame> frames;
        static IDataProvider stringProvider;
        static IKernel kernel;

        public static void Main(string[] args)
        {
            var calc = new Calculator();

            while (true)
            {
                var key = Console.ReadKey(true);
                calc.SendKeystroke(key.KeyChar);
                Console.Clear();
                Console.Write(calc.DisplayText);
            }
            Init();
            ParseFramesFromString(args);
            DispalyScores();
        }
        public static void ParseFramesFromString(string[] args)
        {
            var framesFromString = stringProvider.GetList(args);
            foreach (var frm in framesFromString)
            {
                frames.Add(frm);
            }
        }

        public static void DispalyScores()
        {
            var computedScoredFrame = scorer.GetResult(frames);
            foreach (var frame in computedScoredFrame)
            {

                Console.WriteLine("First Throw :" + frame.FirstThrow + " " +
                    "Second Throw : " + frame.SecondThrow + " " +
                    "Score : " + frame.FrameScored + Environment.NewLine +
                    "---------------------------------------");
            }
        }

        private static void Init()
        {
            kernel = new StandardKernel(new CoreModule());
            scorer = new Scorer(kernel);
            frames = new List<Frame>();
            stringProvider = kernel.Get<StringDataProvider>();
        }
    }
}
