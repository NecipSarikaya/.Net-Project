namespace business.Concrete
{
    public static class HelperMethods
    {
        public static bool Check2intParameters(int p1,int p2){
            if(p1 == 0 || p2 == 0 )
                return false;
            else
                return true;
        }
        public static bool Check1intParameters(int p1){
            if(p1 == 0 )
                return false;
            else
                return true;
        }
         public static bool Check2stringParameters(string p1,string p2){
            if(string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2))
                return false;
            else
                return true;
        }
        public static bool Check1stringParameters(string p1){
            if(string.IsNullOrEmpty(p1)  )
                return false;
            else
                return true;
        }
    }
}