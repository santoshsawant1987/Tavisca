using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public interface IGame
{
    List<Frame> frames { get; set; }
    void Add(Frame frame);
    int ComputeCurrentScore(Frame frame);
    int Count();
    Frame GetFrameByIndex(int index);
    int GetPreviousScore(Frame frame);
}
