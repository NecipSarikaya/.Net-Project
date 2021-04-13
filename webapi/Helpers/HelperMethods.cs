namespace webapi.Helpers
{
    public  class HelperMethods
    {
        public static string getRozetUrl(int UserPoint)
        {
            if(UserPoint == 0){
                return  "http://localhost:5000/Images/first.jpeg";
            }else if(UserPoint > 0 && UserPoint <5){
                return "http://localhost:5000/Images/second.jpeg";
            }else if(UserPoint >= 5 && UserPoint <15){
                return "http://localhost:5000/Images/third.jpeg";
            }else if(UserPoint >= 15 && UserPoint <25){
               return "http://localhost:5000/Images/fourth.jpeg";
            }else if(UserPoint >= 25 && UserPoint <50){
                return "http://localhost:5000/Images/fifth.jpeg";
            }else if(UserPoint >= 50 && UserPoint <75){
                return "http://localhost:5000/Images/sixth.jpeg";
            }else if(UserPoint >= 75 ){
                return "http://localhost:5000/Images/seventh.jpeg";
            }
            return "http://localhost:5000/Images/first.jpeg";
        }
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