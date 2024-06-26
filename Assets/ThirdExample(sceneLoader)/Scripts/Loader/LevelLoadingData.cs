using System;

public class LevelLoadingData 
{
    private int _level;

    public LevelLoadingData(int level)
    {
        Level = level;
    }

    public int Level
    {
        get => _level;
        set
        {
            if(value < 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _level = value;
        }
    }
}
