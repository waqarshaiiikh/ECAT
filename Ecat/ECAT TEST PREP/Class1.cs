using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAT_TEST_PREP
{
    public static class DATAS
    {   //  database path 
        public static String database = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=U:/pract-master/DATABASE/ECAT(DATABASE).accdb;";
        public static int[] english_mcqs = new int[250];
        public static int score = 0;//ned score
        public static int physic_score = 0;
        public static int chemistry_score = 0;
        public static int review = 0;
        public static int math_score = 0;
        public static int english_score = 0;
        public static string[] save_option = new string[300];


        public static int[] chemistry_mcqs = new int[250];
        public static int s_c_lenght_p;
        public static int s_c_lenght_e;
        public static int s_c_lenght_m;
        public static int s_c_lenght_c;
        public static int s_c_lenght;

        public static string[] p_selected_chapter = new string[100];
        public static string[] c_selected_chapter = new string[100];
        public static string[] e_selected_chapter = new string[100];
        public static string[] m_selected_chapter = new string[100];
        public static string[] selected_chapter = new string[100];




        public static int[] math_mcqs = new int[250];
        public static int[] physic_mcqs = new int[250];
        public static string cadidates_name;
        public static string father_name;
        public static string perparation;
        public static int practice = 0;
        public static int assessment = 0;
        public static int Nust_status = 0;
        public static int Ned_status = 0;
        public static int Design_Pattern_status = 0;
        public static int Chapters_status = 0;
        public static int Nust_time_status = 0;
        public static int Ned_default_time = 59;
        public static int Ned_time_status = 0;
        public static int Ned_default_physics_mcqs = 25;
        public static int Ned_default_chemistry_mcqs = 25;
        public static int Ned_default_english_mcqs = 25;
        public static int Ned_default_math_mcqs = 25;
        public static int Nust_default_time = 59;
        public static int Nust_default_MCQS = 200;
        public static int Nust_default_physics_mcqs = 50;
        public static int Nust_default_chemistry_mcqs = 50;
        public static int Nust_default_english_mcqs = 20;
        public static int Nust_default_math_mcqs = 80;
        public static int design_pattern_time_status = 0;
        public static int chapter_time_status = 0;
        public static string required_PHYSICS_MCQS = 0.ToString();
        public static string required_CHEMISTRY_MCQS = 0.ToString();
        public static string required_ENGLISH_MCQS = 0.ToString();
        public static string required_MATH_MCQS = 0.ToString();
        public static string required_MATH_TIME;
        public static string required_PHYSICS_TIME;
        public static string required_CHEMISTRY_TIME;
        public static string required_ENGLISH_TIME;
        public static string each_MCQS_TIME;
        public static string whole_MCQS_TIME;
        public static int each_MCQS_TIME_status;
        public static int whole_MCQS_TIME_status;
        public static string chapter_individual_time;
        public static string chapter_chapter_time;
        public static string chapter_overall_time;

    }
}
