using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace MontyHallProblem_v1._0
{
    public partial class Form1 : Form
    {
        #region Tanımlamalar

        Random r = new Random();

        Stopwatch sw = new Stopwatch();

        #endregion

        #region Değişkenler

        int tur;

        string sonuc = "";

        double doğru1 = 0, yanlış1 = 0;
        double doğru2 = 0, yanlış2 = 0;

        double rast1,rast2,rast3,rast4;

        bool değişim = false;

        int hediyekapı=0,PcSeçimi=0,AçılanKapı=0,YeniSeçim=0;

        #endregion

        #region İşlemler

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw.Start();

            tur = int.Parse(textBox11.Text);

            #region Monty Hall Döngü

            for (int i = 0; i < tur; i++)
            {

                #region Hediye Kapı Belirleme

                rast1 = r.Next(0, 11) * 0.1;

                if (rast1 <= 0.4) hediyekapı = 1;

                else if (rast1 > 0.4 && rast1 <= 0.7) hediyekapı = 2;

                else hediyekapı = 3;

                #endregion

                #region Bilgisayar İlk Seçim

                rast2 = (r.Next(11)) * 0.1;

                if (rast2 <= 0.4) PcSeçimi = 1;

                else if (rast2 > 0.4 && rast2 <= 0.7) PcSeçimi = 2;

                else PcSeçimi = 3;

                #endregion

                #region Bilgisayarın Açtığı Kapı

                if (hediyekapı == PcSeçimi)
                {
                    rast2 = r.Next(11) * 0.1;

                    if (rast3 <= 0.5)
                    {
                        if (hediyekapı == 1)
                        {
                            AçılanKapı = 2;
                        }

                        else if (hediyekapı == 2)
                        {
                            AçılanKapı = 1;
                        }

                        else
                        {
                            AçılanKapı = 1;
                        }
                    }

                    else
                    {
                        if (hediyekapı == 1)
                        {
                            AçılanKapı = 3;
                        }

                        else if (hediyekapı == 2)
                        {
                            AçılanKapı = 3;
                        }

                        else
                        {
                            AçılanKapı = 2;
                        }
                    }
                }

                else
                {
                    if (hediyekapı == 1 && PcSeçimi == 2)
                    {
                        AçılanKapı = 3;
                    }

                    else if (hediyekapı == 1 && PcSeçimi == 3)
                    {
                        AçılanKapı = 2;
                    }

                    else if (hediyekapı == 2 && PcSeçimi == 1)
                    {
                        AçılanKapı = 3;
                    }

                    else if (hediyekapı == 2 && PcSeçimi == 3)
                    {
                        AçılanKapı = 1;
                    }

                    else if (hediyekapı == 3 && PcSeçimi == 1)
                    {
                        AçılanKapı = 2;
                    }

                    else if (hediyekapı == 3 && PcSeçimi == 2)
                    {
                        AçılanKapı = 1;
                    }
                }

                #endregion

                #region YeniSeçim

                rast4 = (r.Next(11)) * 0.1;

                if (rast4 <= 0.5)
                {
                    değişim = true;

                    if (PcSeçimi == 1 && AçılanKapı == 2)
                    {
                        YeniSeçim = 3;
                    }

                    else if (PcSeçimi == 1 && AçılanKapı == 3)
                    {
                        YeniSeçim = 2;
                    }

                    else if (PcSeçimi == 2 && AçılanKapı == 1)
                    {
                        YeniSeçim = 3;
                    }

                    else if (PcSeçimi == 2 && AçılanKapı == 3)
                    {
                        YeniSeçim = 1;
                    }

                    else if (PcSeçimi == 3 && AçılanKapı == 1)
                    {
                        YeniSeçim = 2;
                    }

                    else if (PcSeçimi == 3 && AçılanKapı == 2)
                    {
                        YeniSeçim = 1;
                    }
                }

                else
                {
                    değişim = false;
                    YeniSeçim = PcSeçimi;
                }

                #endregion

                #region Kontrol

                if (hediyekapı == YeniSeçim && değişim == true)
                {
                    sonuc = "Doğru";
                    doğru1++;
                }

                else if (hediyekapı == YeniSeçim && değişim == false)
                {
                    sonuc = "Doğru";
                    doğru2++;
                }

                else if (hediyekapı != YeniSeçim && değişim == true)
                {
                    sonuc = "Yanlış";
                    yanlış1++;
                }

                else if (hediyekapı != YeniSeçim && değişim == false)
                {
                    sonuc = "Yanlış";
                    yanlış2++;
                }


                #region Değer Yazdır

                int sira = listView1.Items.Count;
                listView1.Items.Add((sira + 1).ToString());
                listView1.Items[sira].SubItems.Add(hediyekapı.ToString());
                listView1.Items[sira].SubItems.Add(PcSeçimi.ToString());
                listView1.Items[sira].SubItems.Add(değişim.ToString());
                listView1.Items[sira].SubItems.Add(YeniSeçim.ToString());
                listView1.Items[sira].SubItems.Add(sonuc);

                #endregion

                #endregion
            }

            #endregion

            #region Sonuç Yazdır


            textBox1.Text = (doğru1 + doğru2).ToString();
            textBox2.Text = (yanlış1 + yanlış2).ToString();

            textBox3.Text = doğru1.ToString();
            textBox4.Text = yanlış1.ToString();

            textBox5.Text = doğru2.ToString();
            textBox6.Text = yanlış2.ToString();

            textBox8.Text = (doğru1 / (doğru1 + doğru2)).ToString();
            textBox9.Text = (doğru2 / (doğru1 + doğru2)).ToString();

            textBox7.Text = (yanlış1 / (yanlış1 + yanlış2)).ToString();
            textBox10.Text = (yanlış2 / (yanlış1 + yanlış2)).ToString();

            #endregion

            textBox12.Text = sw.Elapsed.ToString();
        }

        #endregion

    }
}
