namespace Beam.Logic
{
    public class MyBeam
    {
        // Only modified in constructor
        private readonly string _text;

        public MyBeam(string text)
        {
            _text = text;
        }

        public static string GetValidatedBeamScore(string text)
        {
            int scoreTotal = 0;
            int scoreConnection = 0;
            int scoreCrossbar = 0;
            int countConnection = 0;
            int countCrossbar = 0;
            string connection = "=";
            string crossbar = "*";
            string textCharfirst = String.Empty;

            if (text.Length > 0)
            {
                textCharfirst = text[..1];

                if (textCharfirst == "%" || textCharfirst == "&" || textCharfirst == "#")
                {
                    for (int i = 1; i < text.Length; i++)
                    {
                        
                        var flag = text.Substring(i, 1);

                        if (flag == connection)
                        {
                            countCrossbar = 0;
                            countConnection++;
                            scoreConnection += countConnection;
                        }

                        if (flag == crossbar)
                        {
                            countCrossbar++;
                            scoreCrossbar = scoreConnection * 2;

                            if (countCrossbar >= 1)
                            {
                                countConnection = 0;
                            }

                            if (countCrossbar > 1)
                            {
                                return "The beam is poorly built!";
                            }
                        }

                        scoreTotal = scoreConnection + scoreCrossbar;
                    }
                }
                else
                {
                    return "The beam is poorly built!";
                }
            }

            bool isValid = GetMessageOutput(scoreTotal, textCharfirst);

            if (isValid)
            {
                return "The beam supports the weight!";
            }
            else
            {
                return "The beam does not support the weight!";
            }

        }
        private static bool GetMessageOutput(int scoreTotal, string textCharfirst)
        {
            if (textCharfirst == "%")
            {
                return scoreTotal <= 10;

            }
            else if (textCharfirst == "&")
            {
                return scoreTotal <= 30;

            }
            else if (textCharfirst == "#")
            {
                return scoreTotal <= 90;
            }

            return false;
        }
    }
}
