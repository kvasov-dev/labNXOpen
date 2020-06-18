using NXOpen;
using NXOpen.UF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NXOpen.Utilities;
using Point = NXOpen.Point;

namespace project_nx
{
    public class core
    {
        public string name = "core";
        public double D = 12;
        public double d1 = 30;
        public double d = 52;
        public double L = 62;
        public double l1 = 6;

        public double l2 = 18;
        public double l3 = 6;
        public double R1 = 2;
      
        private Tag[] objarray1;

        [STAThread]
        private void createBolt(staple config)
        {
            List<NXOpen.Point> points = new List<Point>() {
                new NXOpen.Point(0, 0),
                new Point(0, config.D / 2 ),
                new Point(0, config.D / 2 ),
                 new Point(config.l2, config.D / 2 ),
                 new Point(config.l2, config.d1 / 2 ),
                 new Point(config.L - config.l - config.l1, config.d / 2 ), // 4  
                 new Point(config.L - config.l - config.l1, config.D / 2 ),
                 new Point(config.L - config.l, config.D / 2),
                 new Point(config.L - config.l, config.d / 2),
                 new Point(config.L, config.d / 2),
                 new Point(config.L, 0),
                 new Point(0, 0)
            };
            List<UFCurve.Line> lines = new List<UFCurve.Line>();
            Tag[] objarray1 = new Tag[points.Count - 1];
            for (int i = 1; i < points.Count; i++)

            {
                UFCurve.Line line = new UFCurve.Line();
                line.start_point = new double[3] { points[i - 1].x, points[i - 1].y, points[i - 1].z };
                line.end_point = new double[3] { points[i].x, points[i].y, points[i].z };

                lines.Add(line);

                ufSession.Curve.CreateLine(ref line, out objarray1[i - 1]);
                Tag[] features1;
                ufSession.Modl.CreateRevolved(objarray1, new string[2] { "0", "360" },

                new double[3] { 0.00, 0.00, 0.00 },
                new double[3] { 1.00, 0.00, 0.00 }, FeatureSigns.Nullsign, out features1); ;


                Tag feat = features1[0];
                Tag cyl_tag, obj_id_camf, blend1;
                Tag[] Edge_array_cyl, face_array;


                int ecount;
                ufSession.Modl.AskFeatBody(feat, out cyl_tag);
                ufSession.Modl.AskBodyEdges(cyl_tag, out Edge_array_cyl);
                ufSession.Modl.AskListCount(Edge_array_cyl, out ecount);

                ArrayList main_1_blend = new ArrayList();
                ArrayList main_1_blend_sub = new ArrayList();
                ArrayList main_2_blend = new ArrayList();
                ArrayList main_2_blend_sub = new ArrayList();


                ArrayList main_3_blend = new ArrayList();


                for (int ii = 0; ii < ecount; ii++)

                    Tag edge;
                ufSession.Modl.AskListItem(Edge_array_cyl, ii, out edge);

                if (ii == 0 || ii == 7)

                {

                    main_1_blend.Add(edge);

                }


                if (ii == 1 || ii == 2)

                {

                    main_1_blend_sub.Add(edge);

                }

                if (ii == 3 || ii == 4)

                {

                    main_2_blend.Add(edge);

                }



                if (ii == 5)

                {

                    main_2_blend_sub.Add(edge);

                }



                if (ii == 6)

                {

                    main_3_blend.Add(edge);

                }

            }


            ufSession.Modl.CreateBlend((config.l2 / 2).ToString(),

            (Tag[])main_1_blend.ToArray(typeof(Tag)), 0, 0, 0, 0.0, out blend1);



            ufSession.Modl.CreateBlend((config.R2).ToString(),

             (Tag[])main_1_blend_sub.ToArray(typeof(Tag)), 0, 0, 0, 0.0, out blend1);



            ufSession.Modl.CreateBlend((config.R3).ToString(),

             (Tag[])main_2_blend.ToArray(typeof(Tag)), 0, 0, 0, 0.0, out blend1);


            ufSession.Modl.CreateBlend((config.R1).ToString(),

            (Tag[])main_2_blend_sub.ToArray(typeof(Tag)), 0, 0, 0, 0.0, out blend1);



            ufSession.Modl.CreateChamfer(3, "1", "1", "45", (Tag[])main_3_blend.ToArray(typeof(Tag)), out obj_id_camf);

            101. }

    }
}
    }
}
