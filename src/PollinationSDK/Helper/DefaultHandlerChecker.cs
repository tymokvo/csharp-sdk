namespace PollinationSDK
{
    public class DefaultHandlerChecker: HandlerChecker
    {

        private static DefaultHandlerChecker _instance;

        public static DefaultHandlerChecker Instance
        {
            get
            {
                _instance = _instance ?? new DefaultHandlerChecker();
                return _instance; 
            }
            set { _instance = value; }
        }

        private DefaultHandlerChecker()
        {

        }

        public override object InvokePythonFunction(string module, string function, object data)
        {
            return data;
        }


    }
}
