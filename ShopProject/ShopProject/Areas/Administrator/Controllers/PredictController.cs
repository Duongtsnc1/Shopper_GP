﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopProject.Areas.Administrator.Sales;
using GP;
using System.IO;
using ShopProject.Areas.Administrator.Models;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class PredictController : Controller
    {
        private static List<Sale> List;
        Models.AdminContext dbPre = new Models.AdminContext();
        // GET: Administrator/Predict
        public ActionResult TestDLL()
        {

            // string[] datatraining = { "81.673509 81.669030 81.682467 81.677988 81.655593 12.000000", "85.190598 93.667817 68.236158 76.713378 69.099477 12.000000", "100.216161 78.731032 93.186418 71.701289 64.275645 12.000000", "64.824162 53.938164 86.596158 75.710161 71.280170 12.000000", "93.014661 61.525192 55.993598 74.504130 67.056785 12.000000", "91.088078 74.733017 73.798199 57.443139 75.667835 12.000000", "80.696928 59.622708 72.845365 51.771146 96.400053 12.000000", "51.173449 98.924641 55.671063 53.422256 92.178221 12.000000", "75.202888 78.603507 68.401648 71.802268 88.805366 12.000000", "97.540216 97.331864 97.956919 97.748567 96.706808 12.000000", "97.469530 53.580548 85.247494 91.358512 71.913603 12.000000", "74.198260 85.129305 52.336171 63.267216 67.922438 12.000000", "55.153009 62.525778 90.407471 97.780240 84.644086 12.000000", "96.391495 70.553769 98.066946 72.229220 93.040594 12.000000", "81.477075 59.938442 74.554342 53.015708 95.322542 12.000000", "61.666023 51.968475 81.061121 71.363573 72.875830 12.000000", "79.845935 57.616036 74.305732 52.075833 90.926340 12.000000", "77.788124 54.368150 74.628073 51.208099 84.108227 12.000000", "65.389926 63.760217 68.649341 67.019633 58.871092 12.000000", "96.339462 64.511983 59.994423 78.166943 69.029542 12.000000", "53.548181 88.759441 83.125661 68.336921 94.393221 12.000000", "54.557718 70.457465 72.758224 88.657971 68.156705 12.000000", "64.838644 77.777832 88.960266 51.899455 66.595398 12.000000", "86.143732 75.642887 57.145421 96.644577 94.140352 12.000000", "92.608793 88.943163 99.940053 96.274424 77.946273 12.000000", "80.385950 95.542567 100.072714 65.229332 91.012421 12.000000", "78.567881 76.319326 83.064994 80.816438 69.573658 12.000000", "58.654969 90.915960 94.132989 76.393979 87.698931 12.000000", "96.822021 68.980042 52.505980 74.664001 85.454105 12.000000", "65.722362 71.814920 53.537247 59.629804 90.092593 12.000000", "86.797407 69.036881 72.318459 54.557934 65.755304 12.000000", "77.616867 50.734366 81.381869 54.499368 70.086864 12.000000", "75.455417 90.238087 95.890078 60.672747 84.586097 12.000000", "77.036981 77.928128 75.254687 76.145834 80.601567 12.000000", "79.469047 65.223898 57.959346 93.714197 72.488451 12.000000", "55.412557 82.208131 51.821409 78.616984 62.594851 12.000000", "94.216856 89.333641 53.983286 99.100071 74.683996 12.000000", "88.301323 83.151641 98.600690 93.451007 67.702592 12.000000", "62.513388 65.300951 56.938263 59.725826 73.663638 12.000000", "88.202342 56.114621 52.377785 70.290063 59.851458 12.000000", "76.670302 99.693297 80.624315 53.647309 68.762279 12.000000", "88.381859 56.752354 51.640868 70.011364 61.863841 12.000000", "70.787670 84.654052 93.054905 56.921288 76.253199 12.000000", "69.783469 62.750415 83.849579 76.816524 91.651249 12.000000", "99.908978 68.649420 62.428094 81.168536 74.870746 12.000000", "84.410908 74.445231 54.342264 94.376585 94.548197 12.000000", "60.916376 66.424653 99.899821 55.408099 82.949485 12.000000", "96.136368 94.145553 100.117998 98.127183 88.173107 12.000000", "69.655917 80.306409 98.354934 59.005425 62.257885 12.000000", "79.139463 53.841967 79.734454 54.436958 77.949479 12.000000", "65.908603 74.079308 99.567191 57.737897 98.591426 12.000000", "55.092470 89.105335 87.066740 71.079605 91.143930 12.000000", "94.385718 63.799567 55.558020 74.971869 72.041114 12.000000", "89.778303 61.227109 96.880693 68.329498 75.573525 12.000000", "66.131375 71.627976 55.138173 60.634774 88.117779 12.000000", "54.591944 61.851446 90.072940 97.332442 83.629952 12.000000", "51.547629 93.765751 67.111387 59.329507 70.420114 12.000000", "66.898307 62.703911 75.287100 71.092704 100.120723 12.000000", "67.985645 99.213421 55.530094 86.757870 92.896747 12.000000", "78.595352 94.653337 96.479385 62.537369 92.827288 12.000000", "51.518937 74.854700 54.847412 78.183175 94.861989 12.000000", "64.587731 93.777625 56.207943 85.397837 81.347308 12.000000", "82.461794 84.460206 78.464970 80.463382 90.455440 12.000000", "71.871476 79.772436 56.069557 63.970516 53.475315 12.000000", "56.528957 94.932255 79.722361 68.125659 60.142149 12.000000", "57.253769 92.781809 86.197686 71.725727 99.365932 12.000000", "60.644031 95.450284 91.031528 75.837780 99.869040 12.000000", "93.604231 96.285909 88.240877 90.922555 54.330941 12.000000", "52.467738 82.261381 92.880454 72.674096 71.642307 12.000000", "94.207573 85.203609 62.215499 53.211536 58.191720 12.000000", "72.188180 89.483207 87.598125 54.893153 91.368290 12.000000", "95.044819 52.913304 79.307850 87.176335 76.518758 12.000000", "51.229949 60.394239 82.901368 92.065657 87.887111 12.000000", "80.486445 67.926887 55.605560 93.046002 80.248215 12.000000", "55.814872 92.882482 81.679654 68.747263 54.085310 12.000000", "68.280930 68.838583 67.165624 67.723277 70.511542 12.000000", "70.043211 60.768283 88.593065 79.318139 82.943502 12.000000", "71.243795 74.687438 64.356509 67.800152 85.018367 12.000000", "77.940325 61.025633 61.769707 94.855016 60.281559 12.000000", "81.603076 50.701681 93.405864 62.504470 57.997499 12.000000", "92.091498 77.071610 72.131275 57.111387 82.011944 12.000000", "67.476971 56.622440 89.186033 78.331502 74.058847 12.000000", "56.709368 64.504039 91.120027 98.914697 87.888051 12.000000", "61.918760 55.427851 74.900576 68.409668 85.955126 12.000000", "59.668031 77.327594 74.348905 92.008468 80.306282 12.000000", "52.864979 84.696668 89.201598 71.033288 80.191738 12.000000", "93.900543 76.859614 77.982402 60.941472 75.736826 12.000000", "56.198452 55.369715 57.855928 57.027190 52.883501 12.000000", "87.078428 79.346080 52.543121 94.810774 56.149040 12.000000", "65.052589 74.000898 97.155968 56.104278 50.845829 12.000000", "56.440611 51.698944 65.923944 61.182278 87.473944 12.000000", "52.033025 94.356085 67.386903 59.709965 71.325266 12.000000", "55.563718 92.698176 81.294800 68.429259 54.101553 12.000000", "99.844264 93.443305 62.646180 56.245221 74.240431 12.000000", "62.595941 72.151494 93.484834 53.040387 50.818154 12.000000", "62.040481 90.673244 54.774955 83.407718 76.571534 12.000000", "66.624123 85.693947 78.484477 97.554300 92.903416 12.000000", "53.460800 58.192567 93.997265 98.729033 72.387869 12.000000", "55.300774 83.616995 98.668331 76.984553 68.565659 12.000000", "78.080555 55.748511 72.744645 100.412601 88.752376 12.000000" };
            
            return View();
        }
        public List<Sale> ListDayByDay(string ID)
        {
            List<Sale> ListS = new List<Sale>();
            var Details = dbPre.OrderDetails.Where(s => s.proID == ID).ToList();
            foreach (var item in Details)
            {
                var datatime = dbPre.Orders.SingleOrDefault(s => s.orderID == item.orderID).orderDateTime;
                if (ListS.Where(s => s.orderDateTime == datatime.ToString("dd/MM/yyyy")).Count() == 0)
                {
                    ListS.Add(new Sale(datatime.ToString("dd/MM/yyyy"), item.ordtsQuantity));
                }
                else
                {
                    int index = ListS.FindIndex(s => s.orderDateTime == datatime.ToString("dd/MM/yyyy"));
                    ListS[index].totalQuantity += item.ordtsQuantity;
                }
            }
            return ListS;
        }
        public List<double> makeListWeekbyWeek(List<Sale> ListS)
        {
            List<double> tranning = new List<double>();
            int jndex = 0;
            double temp = 0;
            ListS.Reverse();
            foreach (var item in ListS)
            {
                jndex++;
                temp += (double)item.totalQuantity;
                if (jndex == 7)
                {
                    tranning.Add(temp);
                    jndex = 0;
                    temp = 0;
                }
            }
            tranning.Reverse();
            return  tranning;
        }
        public string[][] MakeTranning(List<double> Weeks)
        {
            int WeeksLength = Weeks.Count;
            string[][] tranning=new string[WeeksLength-8][];          
            for(int i = 0; i < WeeksLength-8; i++)
            {
                tranning[i] = new string[9];
                for(int j = 0; j <= 8; j++)
                {
                    tranning[i][j] = Weeks[i + j].ToString();
                }
            }
            return tranning;

        }
        [HandleError]
        public ActionResult Index(string error,string ID,string method="")
        {
            if (ID != null && ID.Split('-').Length>1)
            {
                ID = ID.Split('-')[1];
            }
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                
                ViewBag.PreError = error;
                if (!string.IsNullOrEmpty(ID))
                {
                    ViewBag.Product = dbPre.Products.SingleOrDefault(s => s.proID == ID);
                    if (ViewBag.Product != null)
                    {
                        List<Sale> ListS = ListDayByDay(ID);                        
                        List = ListS;
                        ViewBag.ID = ID;
                        
                    }
                    
                    if (List != null)
                    {
                        ViewBag.Detail = List;
                    }
                }
                if (method != "")
                {
                    
                    List<double> Weeks = makeListWeekbyWeek(List);
                    if (dbPre.tranning_models.SingleOrDefault(s => s.ID_GP == ("GP" + method) && s.proID == ID) == null)
                    {                        
                        string[][] tranning = MakeTranning(Weeks);
                        string[][] result = MainGP.Run(ID, tranning, method);
                        tranning_model t_model = new tranning_model();
                        int result_length = result.Length;
                        string model_ = "";
                        for (int i = 0; i < result_length; i++)
                        {
                            model_ += result[i][0] + "@";
                        }
                        t_model.ID_GP = "GP" + method;
                        t_model.proID = ID;
                        t_model.model = model_.Remove(model_.Length-1);
                        dbPre.tranning_models.Add(t_model);
                        dbPre.SaveChanges();
                    }

                    string[] model = dbPre.tranning_models.SingleOrDefault(s => s.ID_GP == ("GP" + method) && s.proID == ID).model.Split('@');
                    string[] input = new string[8];
                    int index = 0;
                    for(int i=Weeks.Count - 8; i < Weeks.Count; i++)
                    {
                        input[index++] = (Weeks[i]).ToString();
                    }
                    PredictGP.Predict PR = new PredictGP.Predict();
                   
                    ViewBag.Predict =  PR.PredictTwo(model, input); 
                }
                return View();
            }
        }
        [HandleError]
        public ActionResult Index1(string error, string ID, string method = "")
        {
            if (ID != null && ID.Split('-').Length > 1)
            {
                ID = ID.Split('-')[1];
            }
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {

                ViewBag.PreError = error;
                if (!string.IsNullOrEmpty(ID))
                {
                    ViewBag.Product = dbPre.Products.SingleOrDefault(s => s.proID == ID);
                    if (ViewBag.Product != null)
                    {
                        List<Sale> ListS = ListDayByDay(ID);
                        List = ListS;
                        ViewBag.ID = ID;

                    }

                    if (List != null)
                    {
                        ViewBag.Detail = List;
                    }
                }
                if (method != "")
                {
                    List<double> Weeks = makeListWeekbyWeek(List);
                    string[][] tranning = MakeTranning(Weeks);
                    string[][] result = MainGP.Run(ID, tranning, method);
                    int result_length = result.Length;
                    string model = "";                    
                    for (int i = 0; i < result_length; i++)
                    {
                        model += result[i][0] + "@";
                    }
                    tranning_model t_model = new tranning_model();
                    t_model.ID_GP = "GP"+method;
                    t_model.proID = ID;
                    t_model.model = model.Remove(model.Length - 1);
                    dbPre.tranning_models.Add(t_model);
                    dbPre.SaveChanges();
                    ViewBag.Result = "Huấn luyện thành công phương pháp " +method;
                }
                return View();
            }
        }
    }
}