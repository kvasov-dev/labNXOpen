using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using NXOpen;
using NXOpenUI;
using NXOpen.UF;
using NXOpen.Utilities;
using System.Net;
using System.Collections;

namespace lab3
{
    namespace lab2_Rotation
    {
        static class Rotation
        {
            public static Form theForm;
            public static UFSession theUfSession;
            /// <summary>
            /// Главная точка входа для приложения.
            /// </summary>
            [STAThread]
            public static int Main(string[] args)

            {

                int retValue = 0;
                theForm = new Form();
                theForm.Show();
                //описание переменных
                Tag UFPart1;
                string name1 = "model_k";
                int units1 = 1;

                try

                {

                    theUfSession = UFSession.GetUFSession();

                    //Session theUfSession = Session.GetSession();

                    theUfSession.Part.New(name1, units1, out UFPart1); //создание новой детали
                                                                       //описание переменных, соотв. конечным точкам отрезков эскиза
                    double[] l1_endpt1 = { 0, 5, 0.00 };

                    double[] l1_endpt2 = { 2, 5, 0.00 };

                    double[] l2_endpt1 = { 2, 5, 0.00 };

                    double[] l2_endpt2 = { 2, 32.5, 0.00 };

                    double[] l3_endpt1 = { 2, 32.5, 0.00 };

                    double[] l3_endpt2 = { -18, 32.5, 0.00 };

                    double[] l4_endpt1 = { -18, 32.5, 0.00 };

                    double[] l4_endpt2 = { -18, 30.5, 0.00 };

                    double[] l5_endpt1 = { -18, 30.5, 0.00 };

                    double[] l5_endpt2 = { 0, 30.5, 0.00 };

                    double[] l6_endpt1 = { 0, 30.5, 0.00 };

                    double[] l6_endpt2 = { 0, 5, 0.00 };

                    //Создание новых структур
                    UFCurve.Line line1 = new UFCurve.Line();

                    UFCurve.Line line2 = new UFCurve.Line();

                    UFCurve.Line line3 = new UFCurve.Line();

                    UFCurve.Line line4 = new UFCurve.Line();

                    UFCurve.Line line5 = new UFCurve.Line();

                    UFCurve.Line line6 = new UFCurve.Line();
                    //Конечные точки отрезков
                    line1.start_point = new double[3];

                    line1.start_point[0] = l1_endpt1[0];

                    line1.start_point[1] = l1_endpt1[1];

                    line1.start_point[2] = l1_endpt1[2];

                    line1.end_point = new double[3];

                    line1.end_point[0] = l1_endpt2[0];

                    line1.end_point[1] = l1_endpt2[1];

                    line1.end_point[2] = l1_endpt2[2];

                    line2.start_point = new double[3];

                    line2.start_point[0] = l2_endpt1[0];

                    line2.start_point[1] = l2_endpt1[1];

                    line2.start_point[2] = l2_endpt1[2];

                    line2.end_point = new double[3];

                    line2.end_point[0] = l2_endpt2[0];

                    line2.end_point[1] = l2_endpt2[1];

                    line2.end_point[2] = l2_endpt2[2];

                    line3.start_point = new double[3];

                    line3.start_point[0] = l3_endpt1[0];

                    line3.start_point[1] = l3_endpt1[1];

                    line3.start_point[2] = l3_endpt1[2];

                    line3.end_point = new double[3];

                    line3.end_point[0] = l3_endpt2[0];

                    line3.end_point[1] = l3_endpt2[1];

                    line3.end_point[2] = l3_endpt2[2];

                    line4.start_point = new double[3];

                    line4.start_point[0] = l4_endpt1[0];

                    line4.start_point[1] = l4_endpt1[1];

                    line4.start_point[2] = l4_endpt1[2];

                    line4.end_point = new double[3];

                    line4.end_point[0] = l4_endpt2[0];

                    line4.end_point[1] = l4_endpt2[1];

                    line4.end_point[2] = l4_endpt2[2];

                    line5.start_point = new double[3];

                    line5.start_point[0] = l5_endpt1[0];

                    line5.start_point[1] = l5_endpt1[1];

                    line5.start_point[2] = l5_endpt1[2];

                    line5.end_point = new double[3];

                    line5.end_point[0] = l5_endpt2[0];

                    line5.end_point[1] = l5_endpt2[1];

                    line5.end_point[2] = l5_endpt2[2];

                    line6.start_point = new double[3];

                    line6.start_point[0] = l6_endpt1[0];

                    line6.start_point[1] = l6_endpt1[1];

                    line6.start_point[2] = l6_endpt1[2];

                    line6.end_point = new double[3];

                    line6.end_point[0] = l6_endpt2[0];

                    line6.end_point[1] = l6_endpt2[1];

                    line6.end_point[2] = l6_endpt2[2];

                    //Создание отрезков в 3D пространстве
                    Tag[] objarray1 = new Tag[7];

                    theUfSession.Curve.CreateLine(ref line1, out objarray1[0]);

                    theUfSession.Curve.CreateLine(ref line2, out objarray1[1]);

                    theUfSession.Curve.CreateLine(ref line3, out objarray1[2]);

                    theUfSession.Curve.CreateLine(ref line4, out objarray1[3]);

                    theUfSession.Curve.CreateLine(ref line5, out objarray1[4]);

                    theUfSession.Curve.CreateLine(ref line6, out objarray1[5]);

                    double[] ref_pt1 = new double[3];

                    ref_pt1[0] = 0.00;

                    ref_pt1[1] = 0.00;

                    ref_pt1[2] = 0.00;

                    double[] direction1 = { 1.00, 0.00, 0.00 };

                    string[] limit1 = { "0", "360" };

                    Tag[] features1;
                    //Операция вращения
                    theUfSession.Modl.CreateRevolved(objarray1, limit1, ref_pt1, direction1, FeatureSigns.Nullsign, out features1);

                    theUfSession.Part.Save();

                    Tag feat = features1[0];

                    Tag cyl_tag, obj_id_camf, blend1;

                    Tag[] Edge_array_cyl, list1, list2;

                    int ecount;

                    theUfSession.Modl.AskFeatBody(feat, out cyl_tag);

                    theUfSession.Modl.AskBodyEdges(cyl_tag, out Edge_array_cyl);

                    theUfSession.Modl.AskListCount(Edge_array_cyl, out ecount);

                    ArrayList arr_list1 = new ArrayList();

                    ArrayList arr_list2 = new ArrayList();

                    for (int ii = 0; ii < ecount; ii++)

                    {

                        Tag edge;

                        theUfSession.Modl.AskListItem(Edge_array_cyl, ii, out edge);

                        if ((ii == 1) || (ii == 2))

                        {

                            arr_list1.Add(edge);

                        }

                        if (ii == 0) { arr_list2.Add(edge); }

                    }

                    list1 = (Tag[])arr_list1.ToArray(typeof(Tag));

                    list2 = (Tag[])arr_list2.ToArray(typeof(Tag));

                    //скругление

                    int allow_smooth = 0;

                    int allow_cliff = 0;

                    int allow_notch = 0;

                    double vrb_tol = 0.0;

                    theUfSession.Modl.CreateBlend("3", list2, allow_smooth, allow_cliff, allow_notch, vrb_tol, out blend1);

                    //фаска

                    string offset1 = "1";

                    string offset2 = "1";

                    string ang = "45";

                    theUfSession.Modl.CreateChamfer(3, offset1, offset2, ang, list1, out obj_id_camf);

                    theUfSession.Part.Save();

                }

                catch (NXOpen.NXException ex)

                {

                }

                return retValue;

            }
        }
    }
}