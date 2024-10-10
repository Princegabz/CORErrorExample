namespace CORError
{
    class Program {
        static void Main(string[] args) 
        {
            ErrorBase Intern = new Junior();
            ErrorBase High = new Senior();
            ErrorBase Expert = new CEO();

            string? Result = null;

            Intern.SetSuccessor(High);
            High.SetSuccessor(Expert);

            Intern.Error(9, Result);
            Console.WriteLine(Result);
        }

        public abstract class ErrorBase
        {
            protected ErrorBase _Successor;
            public abstract void Error(int ErrorLevel, string? Result);
            public void SetSuccessor(ErrorBase Successor) 
            {
                _Successor = Successor;
            }
        }

        public class Junior : ErrorBase
        {
            public override void Error(int ErrorLevel, string? Result)
            {
                if (ErrorLevel == 1)
                {
                    Console.WriteLine("Junior will handle error");
                }
                else
                {
                    Console.WriteLine("Junior will pass error to superior");
                    _Successor.Error(ErrorLevel, Result);
                }
            }
        }
        public class Senior : ErrorBase
        {
            public override void Error(int ErrorLevel, string? Result)
            {
                if (ErrorLevel == 2)
                {
                    Console.WriteLine("Senior will handle error");
                }
                else
                {
                    Console.WriteLine("Senior will pass error to superior");
                    _Successor.Error(ErrorLevel, Result);
                }
            }
        }
        public class CEO : ErrorBase
        {
            public override void Error(int ErrorLevel, string? Result)
            {
                if (ErrorLevel >2)
                {
                    Console.WriteLine("CEO will handle error");
                }
                else
                {
                    Console.WriteLine("Senior will pass error to superior");
                    _Successor.Error(ErrorLevel, Result);
                }
            }
        }
    }

}
