namespace ChattCounterLib
{
    public class ChattCounter
    {
        const int ChangeCount = 3;
        bool Ratch;
        int DiffCounter = ChangeCount;

        public ChattCounter(bool ratch)
        {
            Ratch = ratch;
        }

        public bool Update(bool value)
        {
            if (Ratch != value)
            {
                //フラグの変化がある
                if (0 < DiffCounter)
                {
                    DiffCounter--;
                    if (0 < DiffCounter)
                        return Ratch;   //変化中
                    Ratch = value;      //変化確定
                }
            }

            //カウンタリセット
            DiffCounter = ChangeCount;
            return Ratch;
        }
    }
}
