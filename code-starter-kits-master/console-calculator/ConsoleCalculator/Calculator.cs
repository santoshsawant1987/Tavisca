using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public string DisplayText { get; private set; } = string.Empty;

        public void SendKeystroke(char keyChar)
        {
            int frameScore = 0, prevFrame = 0, prevFrameTwo = 0,
              bowlOne, bowlTwo = 0, frame = 1, totalScore = 0, extraFrame;
            bool strike = false, strikeTwo = false, spare = false;
            String score1 = "", score2 = "", LastFrameTwo = "",
           LastFrameThree = "", frameNum = "", line = "";
            for (; frame <= 10; frame++)
            {
                Console.WriteLine("Please Enter your Scores for Frame 
           { 0}:", frame);
            do
                {
                    Console.Write("Bowl 1:");
                    bowlOne = int.Parse(keyChar);
                } while (bowlOne > 10 || bowlOne < 0);
                if (spare == true)
                {
                    prevFrame = 10 + bowlOne;
                    spare = false;
                    totalScore = prevFrame + totalScore;
                    score2 = scoreTwo(totalScore, score2);
                }
                if (strikeTwo == true && bowlOne == 10)
                {
                    prevFrameTwo = 30;

                    totalScore = prevFrameTwo + totalScore;
                    score2 = scoreTwo(totalScore, score2);
                }
                if (strikeTwo == true && bowlOne != 10)
                {
                    strikeTwo = false;
                    prevFrameTwo = 10 + 10 + bowlOne;
                    totalScore = prevFrameTwo + totalScore;
                    score2 = scoreTwo(totalScore, score2);
                }
                if (strike == true && bowlOne == 10)
                {
                    strikeTwo = true;
                    prevFrameTwo = 20;
                }
                if (bowlOne < 10)
                {
                    do
                    {
                        Console.Write("Bowl 2:");
                        bowlTwo = int.Parse(Console.ReadLine());
                    } while (bowlTwo > (10 - bowlOne) || bowlTwo < 0);
                    if (bowlOne + bowlTwo == 10)
                    {
                        spare = true;
                        score1 += bowlOne + "-/ | ";
                    }
                    if (strikeTwo == true && frame == 10)
                    {
                        prevFrameTwo = 10 + 10 + bowlTwo;
                        totalScore = prevFrameTwo + totalScore;
                        score2 = scoreTwo(totalScore, score2);
                        strikeTwo = false;
                    }
                    if (strike == true && bowlOne != 10)
                    {
                        strike = false;
                        prevFrame = 10 + bowlOne + bowlTwo;
                        totalScore = totalScore + prevFrame;
                        score2 = scoreTwo(totalScore, score2);
                    }
                    if (spare != true && strike != true && strikeTwo !=
                    true)
                    {
                        frameScore = bowlOne + bowlTwo;
                        totalScore = totalScore + frameScore;
                        score2 = scoreTwo(totalScore, score2);
                        if (frame != 10)
                            score1 += " " + bowlOne + "-" + bowlTwo + " 
                           | ";
                         else
                            score1 += " " + bowlOne + "-" + bowlTwo;
                    }
                }
                else
                {
                    strike = true;
                    prevFrame = 10;
                    if (frame != 10)
                        score1 += " X- |";
                }
                if (frame == 10 && strike == true)
                {
                    do
                        bowlTwo = int.Parse(Console.ReadLine());
                    while (bowlTwo < 0 || bowlTwo > 10);
                    if (strikeTwo == true)
                    {
                        prevFrameTwo = 10 + 10 + bowlTwo;
                        totalScore = prevFrameTwo + totalScore;
                        score2 = scoreTwo(totalScore, score2);
                        strikeTwo = false;
                    }
                }
                if (frame == 10 && (spare == true || strike == true))
                {
                    do
                        extraFrame = int.Parse(Console.ReadLine());
                    while (extraFrame < 0 || extraFrame > 10);
                    if (strike == true)
                    {
                        prevFrame = 10 + bowlTwo + extraFrame;
                        totalScore = totalScore + prevFrame;
                        score2 = scoreTwo(totalScore, score2);
                        if (bowlTwo == 10)
                            LastFrameTwo = "-X";
                        else
                            LastFrameTwo += bowlTwo;
                        if (extraFrame == 10)
                            LastFrameThree = "-X";
                        else
                            LastFrameThree += extraFrame;
                        score1 += " X" + LastFrameTwo + LastFrameThree;
                    }
                    else
                    {
                        if (extraFrame == 10)
                            LastFrameThree = "-X";
                        else
                            LastFrameThree += extraFrame;
                        if (bowlTwo + extraFrame == 10 && extraFrame !=
                       10)
                            LastFrameThree = "-/";
                        else
                            LastFrameThree += extraFrame;
                        totalScore = totalScore + 10 + extraFrame;
                        score2 = scoreTwo(totalScore, score2);
                        score1 += bowlOne + "-/" + LastFrameThree;
                    }
                }
                frameNum += frame + " ";
                line += "------";
            }

        }
    }
}

