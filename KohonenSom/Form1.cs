using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KohonenSom
{
    public partial class Form1 : Form
    {
        

        List<string> degiskenIsim = new List<string>();
        List<string> veriler = new List<string>();
        List<string> ceviri = new List<string>();

        List<double> area= new List<double>();
        List<double> retail = new List<double>();
        List<double> rooms = new List<double>();
        List<double> owners = new List<double>();
        List<string>index  = new List<string>();
        List<double> tax = new List<double>();
        List<double>ptratio  = new List<double>();
        List<double> median = new List<double>();

        List<int>A= new List<int>();
        List<int>B= new List<int>();
        List<int>C= new List<int>();
        List<int>D= new List<int>();
        List<int>E= new List<int>();
        List<int>F= new List<int>();
        List<int>G= new List<int>();
        List<int>H= new List<int>();
        List<int>TT= new List<int>();
        List<int> yerlesecekNode = new List<int>();


        List<double>normalizeArea = new List<double>();
        List<double>normalizeRetail = new List<double>();
        List<double>normalizeRooms = new List<double>();
        List<double>normalizeOwners = new List<double>();
        List<double>normalizeTax = new List<double>();
        List<double>normalizePtratio = new List<double>();
        List<double>normalizeMedian= new List<double>();


        Random rastgele = new Random();
        List<double> weights = new List<double>();
        List<double> ciktiDegerler = new List<double>();
        List<double> hij = new List<double>();
        List<double> deltaWj = new List<double>();

        int kayitSayisi = 500;
        int outputNode = 100;
        double ogrenmeHizi = 0.1;
        double sigma = 10;// (10+10)/2
        double sigmaN = 0;
        int t2 = 10;
        int t1 = 10; // 10 / (Math.Log(sigma));

        int indis = 0;
        int iterasyon = 0;
        int degisken1 = 0;
        int degisken2 = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, d, ee, f, g, h, tt;
            a = b = c = d = ee = f = g = h = tt = 0;

            dataGridView1.ColumnCount = 8;
            dataGridView2.ColumnCount = 10;
            dataGridView3.ColumnCount = 16;
           

            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "C:";
            file.ShowDialog();

            FileStream dosya = new FileStream(file.FileName, FileMode.Open);
            dosya.Close();

            StreamReader oku = new StreamReader(file.FileName); 

            string[] ap;
            char ayrac = ',';
            string satir;
            
            
            while (true)
            {
                satir = oku.ReadLine();
                if (string.IsNullOrEmpty(satir))
                    break;

                if (satir.StartsWith("A"))
                {

                    for (int i = 0; i < 8; i++)
                    {
                        ap = (satir.Split(ayrac));
                        degiskenIsim.Add(ap[i]);

                    }

                    for (int i = 0; i < 8; i++)
                    {

                        dataGridView1.Columns[i].Name = degiskenIsim[i].ToString();
                        
                      
                    }

                }

               
                
                else
                {

                    for (int i = 0; i < 8; i++)
                    {

                        ap = (satir.Split(ayrac));
                        veriler.Add(ap[i]);
                        
                       
                    }

                    string str = " ";
                    for (int i = 0; i < veriler.Count; i++)
                    {
                        str = veriler[i];
                        ceviri.Add( str.Replace('.', ','));
                    }

                    

                    dataGridView1.Rows.Add(ceviri[0], ceviri[1], ceviri[2], ceviri[3], ceviri[4], ceviri[5], ceviri[6], ceviri[7]);

                    veriler.Clear();
                    ceviri.Clear();
                }

            }  
            
            oku.Close();

            degiskenIsim.RemoveAt(4);

            for (int i = 0; i < 7; i++)
            {
                dataGridView3.Columns[i].Name = degiskenIsim[i].ToString();
            }

         
            dataGridView3.Columns[7].Name = "A";
            dataGridView3.Columns[8].Name = "B";
            dataGridView3.Columns[9].Name = "C";
            dataGridView3.Columns[10].Name = "D";
            dataGridView3.Columns[11].Name = "E";
            dataGridView3.Columns[12].Name = "F";
            dataGridView3.Columns[13].Name = "G";
            dataGridView3.Columns[14].Name = "H";
            dataGridView3.Columns[15].Name = "TT";

          
          


            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                area.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value));
                retail.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));
                rooms.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                owners.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
                index.Add(dataGridView1.Rows[i].Cells[4].Value.ToString());
                tax.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value));
                ptratio.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value));
                median.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value));


            }

            string harf;

            for (int i = 0; i < index.Count; i++)
            {

                harf = index[i];
                switch(harf)

                {
                    case "A":
                        a = 1; b = c = d = ee = f = g = h = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "B":
                        b = 1; a = c = d = ee = f = g = h = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "C":
                        c = 1; b = a = d = ee = f = g = h = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "D":
                        d = 1; b = c = a = ee = f = g = h = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "E":
                        ee = 1; b = c = d = a = f = g = h = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "F":
                        f = 1; b = c = d = ee = a = g = h = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "G":
                        a = 1; b = c = d = ee = f = a = h = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "H":
                        h = 1; b = c = d = ee = f = g = a = tt = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                    case "TT":
                        tt = 1; b = c = d = ee = f = g = h = a = 0;
                        dataGridView2.Rows.Add(index[i], a, b, c, d, ee, f, g, h, tt);
                        a = b = c = d = ee = f = g = h = tt = 0;
                        break;
                }

                

            }


            for (int i = 0; i < dataGridView2.RowCount-1; i++)
            {
                A.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value));
                B.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value));
                C.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value));
                D.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value));
                E.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value));
                F.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value));
                G.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[7].Value));
                H.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[8].Value));
                TT.Add(Convert.ToInt32(dataGridView2.Rows[i].Cells[9].Value));
            }

            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                dataGridView3.Rows.Add(area[i],retail[i],rooms[i],owners[i],tax[i],ptratio[i],median[i],A[i], B[i], C[i], D[i], E[i], F[i], G[i], H[i], TT[i]);
            }

            //for (int i = 0; i < 9; i++)
            //{
            //    dataGridView2.Rows.Add(area[i],retail[i],rooms[i],owners[i],index[i],tax[i],ptratio[i],median[i]);
            //}

            //rooms.
            //owners
            //index.
            //tax.Ad
            //ptrati
            //median

            double min, max;
            min = max = area[0];
            for (int i = 1; i < area.Count; i++)
            {
                if (area[i] < min) { min = area[i]; }
                if (area[i] > max) { max = area[i]; }
            }
            for (int i = 0; i < area.Count; i++)
            {
                normalizeArea.Add(((double)(area[i]) - (double)(min)) / ((double)(max) - (double)(min)));
            }

            min = max = 0;
            min = max = retail[0];
            for (int i = 1; i < retail.Count; i++)
            {
                if (retail[i] < min) { min = retail[i]; }
                if (retail[i] > max) { max = retail[i]; }
            }
            for (int i = 0; i < retail.Count; i++)
            {
                normalizeRetail.Add(((double)(retail[i]) - (double)(min)) / ((double)(max) - (double)(min)));
            }

            min = max = 0;
            min = max = rooms[0];
            for (int i = 1; i < rooms.Count; i++)
            {
                if (rooms[i] < min) { min = rooms[i]; }
                if (rooms[i] > max) { max = rooms[i]; }
            }
            for (int i = 0; i < rooms.Count; i++)
            {
                normalizeRooms.Add(((double)(rooms[i]) - (double)(min)) / ((double)(max) - (double)(min)));
            }

            min = max = 0;
            min = max = owners[0];
            for (int i = 1; i < owners.Count; i++)
            {
                if (owners[i] < min) { min = owners[i]; }
                if (owners[i] > max) { max = owners[i]; }
            }
            for (int i = 0; i < owners.Count; i++)
            {
                normalizeOwners.Add(((double)(owners[i]) - (double)(min)) / ((double)(max) - (double)(min)));
            }

            min = max = 0;
            min = max = tax[0];
            for (int i = 1; i < tax.Count; i++)
            {
                if (tax[i] < min) { min = tax[i]; }
                if (tax[i] > max) { max = tax[i]; }
            }
            for (int i = 0; i < tax.Count; i++)
            {
                normalizeTax.Add(((double)(tax[i]) - (double)(min)) / ((double)(max) - (double)(min)));
            }

            min = max = 0;
            min = max = ptratio[0];
            for (int i = 1; i < ptratio.Count; i++)
            {
                if (ptratio[i] < min) { min = ptratio[i]; }
                if (ptratio[i] > max) { max = ptratio[i]; }
            }
            for (int i = 0; i < ptratio.Count; i++)
            {
                normalizePtratio.Add(((double)(ptratio[i]) - (double)(min)) / ((double)(max) - (double)(min)));
            }

            min = max = 0;
            min = max = median[0];
            for (int i = 1; i < median.Count; i++)
            {
                if (median[i] < min) { min = median[i]; }
                if (median[i] > max) { max = median[i]; }
            }
            for (int i = 0; i < median.Count; i++)
            {
                normalizeMedian.Add(((double)(median[i]) - (double)(min)) / ((double)(max) - (double)(min)));
            }
            min = max = 0;



            for (int t = 0; t < 16 ; t++) //1. degişken , 2.degişken,.. 16. degişken için 100 adet agırlık atandı.
            {
                for (int r = 0; r < outputNode; r++)
                {
                    weights.Add(rastgele.NextDouble() * (0.5 - (-0.5)) + (-0.5));//*(max-min)+min
                                                                                 //textBox1.Text += weights[r].ToString();
                }

            }





            double areaFarkKare, retailFarkKare, roomsFarkKare, ownersFarkKare, taxFarkKare, ptratioFarkKare, medianFarkKare;
            areaFarkKare = retailFarkKare = roomsFarkKare = ownersFarkKare = taxFarkKare = ptratioFarkKare = medianFarkKare = 0;
            double aFarkKare,bFarkKare,cFarkKare,dFarkKare,eFarkKare,fFarkKare,gFarkKare,hFarkKare,ttFarkKare;
            aFarkKare = bFarkKare = cFarkKare = dFarkKare = eFarkKare = fFarkKare = gFarkKare = hFarkKare = ttFarkKare = 0;
            int temp = 0;
            double sum = 0.0;

            for (int epoch = 0; epoch < 20; epoch++)
            {



                for (int z = 0; z <kayitSayisi; z++)//kayıt
                {
                    for (int i = 0; i < outputNode; i++)//100
                    {

                        for (int t = temp; t < temp + 100; t += 100)
                        {

                            areaFarkKare = Math.Pow((normalizeArea[z] - weights[t]), 2);
                            retailFarkKare = Math.Pow((normalizeRetail[z] - weights[t + 100]), 2);
                            roomsFarkKare = Math.Pow((normalizeRooms[z] - weights[t + 200]), 2);
                            ownersFarkKare = Math.Pow((normalizeOwners[z] - weights[t + 300]), 2);
                            taxFarkKare = Math.Pow((normalizeTax[z] - weights[t + 400]), 2);
                            ptratioFarkKare = Math.Pow((normalizePtratio[z] - weights[t + 500]), 2);
                            medianFarkKare = Math.Pow((normalizeMedian[z] - weights[t + 600]), 2);

                            aFarkKare = Math.Pow((A[z] - weights[t + 700]), 2);
                            bFarkKare = Math.Pow((B[z] - weights[t + 800]), 2);
                            cFarkKare = Math.Pow((C[z] - weights[t + 900]), 2);
                            dFarkKare = Math.Pow((D[z] - weights[t + 1000]), 2);
                            eFarkKare = Math.Pow((E[z] - weights[t + 1100]), 2);
                            fFarkKare = Math.Pow((F[z] - weights[t + 1200]), 2);
                            gFarkKare = Math.Pow((G[z] - weights[t + 1300]), 2);
                            hFarkKare = Math.Pow((H[z] - weights[t + 1400]), 2);
                            ttFarkKare = Math.Pow((TT[z] - weights[t + 1500]), 2);


                        }


                        sum += areaFarkKare + retailFarkKare + roomsFarkKare + ownersFarkKare + taxFarkKare + ptratioFarkKare + medianFarkKare
                               + aFarkKare + bFarkKare + cFarkKare + dFarkKare + eFarkKare + fFarkKare + gFarkKare + hFarkKare + ttFarkKare;

                        ciktiDegerler.Add(Math.Sqrt(sum));
                        temp++;
                        sum = 0;
                    }


                    double kucuk = ciktiDegerler[0];
                    for (int i = 1; i < ciktiDegerler.Count; i++)
                    {
                        if (ciktiDegerler[i] < kucuk) { kucuk = ciktiDegerler[i]; indis = i; }
                    }


                    yerlesecekNode.Add(indis);





                    temp = 0;

                  

                    double[,] outputDizi = new double[10, 10];
                    int sayac = 0;


                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (sayac == indis)
                            {
                                for (int k = 0; k < 10; k++)
                                {
                                    for (int l = 0; l < 10; l++)
                                    {
                                        outputDizi[k, l] = Math.Sqrt((Math.Pow(Math.Abs((i - k)), 2)) + (Math.Pow(Math.Abs((j - l)), 2)));
                                    }
                                }

                                
                            }
                            sayac++;
                        }
                    }

                    sayac = 0;
                    indis = 0;

                    sigmaN = sigma * Math.Exp((double)(-epoch) / (double)t1);

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            hij.Add(Math.Exp((double)(-outputDizi[i, j]) / (double)(2 * Math.Pow(sigmaN, 2))));//her outputun kazanan outputa göre komşuluk fonksiyonu
                        }
                    }



                    //deltaWj.Add( sigmaN * hij[i] * (normalizeArea[i] - weights[i]));

                    
                    for (int i = 0; i < outputNode; i++)//100
                    {
                                for (int t = temp; t < temp + 100; t += 100)
                                {

                                    deltaWj.Add((normalizeArea[z] - weights[t]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((normalizeRetail[z] - weights[t + 100]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((normalizeRooms[z] - weights[t + 200]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((normalizeOwners[z] - weights[t + 300]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((normalizeTax[z] - weights[t + 400]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((normalizePtratio[z] - weights[t + 500]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((normalizeMedian[z] - weights[t + 600]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((A[z] - weights[t + 700]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((B[z] - weights[t + 800]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((C[z] - weights[t + 900]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((D[z] - weights[t + 1000]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((E[z] - weights[t + 1100]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((F[z] - weights[t + 1200]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((G[z] - weights[t + 1300]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((H[z] - weights[t + 1400]) * ogrenmeHizi * hij[i]);
                                    deltaWj.Add((TT[z] - weights[t + 1500]) * ogrenmeHizi * hij[i]);

                                }

                                temp++;
                        
                    }



                    temp = 0;
                   

                    for (int i = 0; i < 100; i++)
                    {

                        for (int p = 0; p < 16; p++)
                        {

                            for (int s = temp; s < temp + 100; s += 100)
                            {

                                weights[s] = weights[s] + deltaWj[p];

                            }

                            temp += 100;
                            

                        }
                        temp = 0;

                    }



                    ogrenmeHizi = ogrenmeHizi * Math.Exp((double)(-epoch) / (double)t2);

                    
                    hij.Clear();
                    ciktiDegerler.Clear();

                   

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            outputDizi[i, j] = 0;
                        }
                    }



                  


                }
                iterasyon = epoch;
            }


            int yerlesim;
            yerlesim = (iterasyon) * kayitSayisi;
            
            


              for (int i = yerlesim; i < yerlesecekNode.Count; i++)
              {
                for (int j = 0; j < 100; j++)
                {
                    if (yerlesecekNode[i] == j)
                    {
                        degisken1 = j % 10;//Y
                        degisken2 = j / 10;//X
                        chart1.Series["Yerleşim Noktaları"].Points.AddXY(degisken2, degisken1);
                    }

                }

                

            }


            }

       
    }
}

