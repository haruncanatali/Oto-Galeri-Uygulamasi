using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Galeri.Business.Abstract;
using Galeri.Business.Ninject;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galeri.DesktopUI.Formlar
{
    public partial class MainForm : Form
    {
        IMarkaService markaServis;
        IModelService modelServis;
        ITasitService aracServis;
        IKategoriService kategoriServis;
        IHasarKayitService hasarKayitServis;
        IFotografService fotografServis;
        IYorumService yorumServis;

        int id;
        string p1, p2, p3, p4, p11, p22, p33, p44;
        public MainForm()
        {
            InitializeComponent();

            markaServis = InstanceFactory.GetInstance<IMarkaService>();
            modelServis = InstanceFactory.GetInstance<IModelService>();
            aracServis = InstanceFactory.GetInstance<ITasitService>();
            kategoriServis = InstanceFactory.GetInstance<IKategoriService>();
            hasarKayitServis = InstanceFactory.GetInstance<IHasarKayitService>();
            fotografServis = InstanceFactory.GetInstance<IFotografService>();
            yorumServis = InstanceFactory.GetInstance<IYorumService>();
        }

        private void aracPageClick(object sender, EventArgs e)
        {
            SayfalamaControl.SelectedTabPage = aracPage;

           
        }
       
        private void MarkaPageLoad()
        {
            SayfalamaControl.SelectedTabPage = markaPage;

            markaGridControl.DataSource = from x in markaServis.GetEntities(null)
                                          select new
                                          {
                                              x.Id,
                                              x.MarkaAdi
                                          };
            id = -1;
            markaAdiTxt.Text = "";
        }

        private void ModelPageLoad()
        {
            SayfalamaControl.SelectedTabPage = modelPage;
            modelGridControl.DataSource = from x in modelServis.GetEntities(null)
                                          select new
                                          {
                                              x.Id,
                                              x.ModelAdi,
                                              x.Yil,
                                              x.KasaTipi,
                                              x.MotorGucu,
                                              x.MotorHacmi,
                                              x.Cekis,
                                              x.AzamiSurat,
                                              x.BagajKapasitesi,
                                              x.Vites,
                                              x.Yakit,
                                              x.MarkaId
                                          };
            markaLookUp.Properties.DataSource = from x in markaServis.GetEntities(null)
                                                select new
                                                {
                                                    MarkaId = x.Id,
                                                    MarkaAdi = x.MarkaAdi
                                                };

            id = -1;
            vitesTxt.Text = "";
            yilTxt.Text = "";
            kasaTipiTxt.Text = "";
            motorGucuTxt.Text = "";
            motorHacmiTxt.Text = "";
            cekisTxt.Text = "";
            azamiSuratTxt.Text = "";
            bagajKapasitesiTxt.Text = "";
            markaLookUp.Text = "";
            yakitTxt.Text = "";
            modelAdiTxt.Text = "";
        }

        private void PageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            XtraTabControl pageControl = (XtraTabControl)sender;

            if (pageControl.SelectedTabPage != null)
            {
                switch (pageControl.SelectedTabPage.Name)
                {
                    case "markaPage":
                        MarkaPageLoad();
                        break;
                    case "modelPage":
                        ModelPageLoad();
                        break;
                    case "kategoriPage":
                        KategoriPageLoad();
                        break;
                    case "aracPage":
                        AracPageLoad();
                        break;
                    case "hasarKayitPage":
                        HasarKayitPageLoad();
                        break;
                    case "yorumPage":
                        YorumPageLoad();
                        break;
                    case "cikisPage":
                        DialogResult result = MessageBox.Show("Sistemden çıkmak istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if(result == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                        else
                        {
                            SayfalamaControl.SelectedTabPage = null;
                        }
                        break;
                    case "fotografPage":
                        FotografPageLoad();
                        break;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SayfalamaControl.SelectedTabPage = null;
        }

        private void MarkaGrid_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            markaAdiTxt.Text = gridView1.GetFocusedRowCellValue("MarkaAdi").ToString();
        }

        private void MarkaPageVtBtns_Click(object sender, EventArgs e)
        {
            SimpleButton buton = (SimpleButton) sender;
            switch (buton.Text.ToString())
            {
                case "Ekle":
                    try
                    {
                        markaServis.Add(new Marka { 
                            MarkaAdi = markaAdiTxt.Text.ToString()
                        });
                        MessageBox.Show("Marka başarıyla eklendi.","Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MarkaPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Güncelle":
                    try
                    {
                        markaServis.Update(new Marka
                        {
                            Id = id,
                            MarkaAdi = markaAdiTxt.Text.ToString()
                        });
                        MessageBox.Show("Marka başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MarkaPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Sil":
                    try
                    {
                        markaServis.Delete(new Marka
                        {
                            Id = id
                        });
                        MessageBox.Show("Marka başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MarkaPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void ModelVtButtons_Click(object sender, EventArgs e)
        {
            SimpleButton btn = (SimpleButton)sender;
            switch (btn.Text)
            {
                case "Ekle":
                    try
                    {
                        modelServis.Add(new Model
                        {
                           Yil = short.Parse(yilTxt.Text.ToString()),
                           KasaTipi = kasaTipiTxt.Text.ToString(),
                           MotorGucu = short.Parse(motorGucuTxt.Text.ToString()),
                           MotorHacmi = short.Parse(motorHacmiTxt.Text.ToString()),
                           Cekis = cekisTxt.Text.ToString(),
                           AzamiSurat = short.Parse(azamiSuratTxt.Text.ToString()),
                           BagajKapasitesi = short.Parse(bagajKapasitesiTxt.Text.ToString()),
                           Yakit = yakitTxt.Text.ToString(),
                           ModelAdi = modelAdiTxt.Text.ToString(),
                           MarkaId = int.Parse(markaLookUp.EditValue.ToString()),
                           Vites = vitesTxt.Text.ToString()
                        });
                        MessageBox.Show("Model başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ModelPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Güncelle":
                    try
                    {
                        modelServis.Update(new Model
                        {
                            Id = id,
                            Yil = short.Parse(yilTxt.Text.ToString()),
                            KasaTipi = kasaTipiTxt.Text.ToString(),
                            MotorGucu = short.Parse(motorGucuTxt.Text.ToString()),
                            MotorHacmi = short.Parse(motorHacmiTxt.Text.ToString()),
                            Cekis = cekisTxt.Text.ToString(),
                            AzamiSurat = short.Parse(azamiSuratTxt.Text.ToString()),
                            BagajKapasitesi = short.Parse(bagajKapasitesiTxt.Text.ToString()),
                            Yakit = yakitTxt.Text.ToString(),
                            ModelAdi = modelAdiTxt.Text.ToString(),
                            MarkaId = int.Parse(markaLookUp.EditValue.ToString()),
                            Vites = vitesTxt.Text.ToString()
                        });
                        MessageBox.Show("Model başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ModelPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Sil":
                    try
                    {
                        modelServis.Delete(new Model
                        {
                            Id = id                         
                        });
                        MessageBox.Show("Model başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ModelPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void ModelGridClick(object sender, EventArgs e)
        {
            int markaId = Convert.ToInt32(gridView2.GetFocusedRowCellValue("MarkaId").ToString());

            id = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());
            yilTxt.Text = gridView2.GetFocusedRowCellValue("Yil").ToString();
            kasaTipiTxt.Text = gridView2.GetFocusedRowCellValue("KasaTipi").ToString();
            motorGucuTxt.Text = gridView2.GetFocusedRowCellValue("MotorGucu").ToString();
            cekisTxt.Text = gridView2.GetFocusedRowCellValue("Cekis").ToString();
            azamiSuratTxt.Text = gridView2.GetFocusedRowCellValue("AzamiSurat").ToString();
            bagajKapasitesiTxt.Text = gridView2.GetFocusedRowCellValue("BagajKapasitesi").ToString();
            markaLookUp.Text = markaServis.GetEntity(c => c.Id == markaId).MarkaAdi;
            yakitTxt.Text = gridView2.GetFocusedRowCellValue("Yakit").ToString();
            modelAdiTxt.Text = gridView2.GetFocusedRowCellValue("ModelAdi").ToString();
            vitesTxt.Text = gridView2.GetFocusedRowCellValue("Vites").ToString();
            motorHacmiTxt.Text = gridView2.GetFocusedRowCellValue("MotorHacmi").ToString();
        }

        private void KategoriVtBtns_Click(object sender, EventArgs e)
        {
            SimpleButton buton = (SimpleButton)sender;
            switch (buton.Text.ToString())
            {
                case "Ekle":
                    try
                    {
                        kategoriServis.Add(new Kategori
                        {
                            KategoriAdi = kategoriAdTxt.Text.ToString()
                        });
                        MessageBox.Show("Kategori başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KategoriPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Güncelle":
                    try
                    {
                        kategoriServis.Update(new Kategori
                        {
                            Id = id,
                            KategoriAdi = kategoriAdTxt.Text.ToString()
                        });
                        MessageBox.Show("Kategori başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KategoriPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Sil":
                    try
                    {
                        kategoriServis.Delete(new Kategori
                        {
                            Id = id
                        });
                        MessageBox.Show("Kategori başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KategoriPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void KategoriGrid_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridView3.GetFocusedRowCellValue("Id").ToString());
            kategoriAdTxt.Text = gridView3.GetFocusedRowCellValue("KategoriAdi").ToString();
        }
        private void KategoriPageLoad()
        {
            SayfalamaControl.SelectedTabPage = kategoriPage;
            kategoriGridControl.DataSource = from x in kategoriServis.GetEntities(null)
                                             select new
                                             {
                                                 x.Id,
                                                 x.KategoriAdi
                                             };

            id = -1;
            kategoriAdTxt.Text = "";
        }
        private void AracPageLoad()
        {
            SayfalamaControl.SelectedTabPage = aracPage;

            tasitGridControl.DataSource = from x in aracServis.GetEntities(null)
                                          select new
                                          {
                                              x.Id,
                                              x.Fiyat,
                                              x.Garanti,
                                              x.Takas,
                                              x.Durum,
                                              x.Renk,
                                              x.Plaka,
                                              x.Aciklama,
                                              x.ModelId,
                                              x.KategoriId,
                                              x.TasitBaslik,
                                              x.Kilometre
                                          };

            modelLook.Properties.DataSource = from x in modelServis.GetEntities(null)
                                              select new
                                              {
                                                  ModelId = x.Id,
                                                  ModelAdi = x.ModelAdi
                                              };
            kategoriLook.Properties.DataSource = from x in kategoriServis.GetEntities(null)
                                                 select new
                                                 {
                                                     KategoriAdi = x.KategoriAdi,
                                                     KategoriId = x.Id
                                                 };


            id = -1;
            fiyatTxt.Text = "";
            garantiRdGrup.Properties.Items[0].Value = 0;
            garantiRdGrup.Properties.Items[1].Value = 0;
            takasRdGrup.Properties.Items[0].Value = 0;
            takasRdGrup.Properties.Items[1].Value = 0;
            durumTxt.Text = "";
            renkTxt.Text = "";
            plakaTxt.Text = "";
            aciklamaZoople.DocumentHTML = "";
            modelLook.Text = "";
            kategoriLook.Text = "";
            baslikTxt.Text = "";
            kilometreTxt.Text = "";
            
        }

        private void AracVtBtns_Click(object sender, EventArgs e)
        {
            SimpleButton buton = (SimpleButton)sender;
            
            switch (buton.Text.ToString())
            {
                case "Ekle":
                    try
                    {
                            aracServis.Add(new Tasit
                            {
                                Fiyat = decimal.Parse(fiyatTxt.Text.ToString()),
                                Garanti = garantiRdGrup.Properties.Items[0].Value.ToString() == "false" ? false : true,
                                Takas = takasRdGrup.Properties.Items[0].Value.ToString() == "false" ? false : true,
                                Durum = durumTxt.Text.ToString(),
                                Renk = renkTxt.Text.ToString(),
                                Plaka = plakaTxt.Text.ToString(),
                                Aciklama = aciklamaZoople.DocumentHTML.ToString(),
                                ModelId = int.Parse(modelLook.EditValue.ToString()),
                                KategoriId = int.Parse(kategoriLook.EditValue.ToString()),
                                TasitBaslik = baslikTxt.Text.ToString(),
                                Kilometre = int.Parse(kilometreTxt.Text.ToString())
                            });
                            MessageBox.Show("Araç başarıyla eklendi.", "Bilgilendirme",        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AracPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Güncelle":
                    try
                    {
                        aracServis.Update(new Tasit
                        {
                            Id = id,
                            Fiyat = decimal.Parse(fiyatTxt.Text.ToString()),
                            Garanti = garantiRdGrup.Properties.Items[0].Value.ToString() == "false" ? false : true,
                            Takas = takasRdGrup.Properties.Items[0].Value.ToString() == "false" ? false : true,
                            Durum = durumTxt.Text.ToString(),
                            Renk = renkTxt.Text.ToString(),
                            Plaka = plakaTxt.Text.ToString(),
                            Aciklama = aciklamaZoople.DocumentHTML.ToString(),
                            ModelId = int.Parse(modelLook.EditValue.ToString()),
                            KategoriId = int.Parse(kategoriLook.EditValue.ToString()),
                            TasitBaslik = baslikTxt.Text.ToString(),
                            Kilometre = int.Parse(kilometreTxt.Text.ToString())
                        });
                        MessageBox.Show("Araç başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AracPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Sil":
                    try
                    {
                        aracServis.Delete(new Tasit
                        {
                            Id = id
                        });
                        MessageBox.Show("Araç başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AracPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void tasitGrid_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridView4.GetFocusedRowCellValue("Id").ToString());

            int kategoriId = int.Parse(gridView4.GetFocusedRowCellValue("KategoriId").ToString());
            int modelId = int.Parse(gridView4.GetFocusedRowCellValue("ModelId").ToString());


            if ((gridView4.GetFocusedRowCellValue("Garanti").ToString()) == "False")
            {
                garantiRdGrup.SelectedIndex = 1;
            }
            else
            {
                garantiRdGrup.SelectedIndex = 0;
            }

            if ((gridView4.GetFocusedRowCellValue("Takas").ToString()) == "False")
            {
                takasRdGrup.SelectedIndex = 1;
            }
            else
            {
                takasRdGrup.SelectedIndex = 0;
            }

            fiyatTxt.Text = gridView4.GetFocusedRowCellValue("Fiyat").ToString();
            durumTxt.Text = gridView4.GetFocusedRowCellValue("Durum").ToString();
            renkTxt.Text = gridView4.GetFocusedRowCellValue("Renk").ToString();
            plakaTxt.Text = gridView4.GetFocusedRowCellValue("Plaka").ToString();
            aciklamaZoople.DocumentHTML = gridView4.GetFocusedRowCellValue("Aciklama").ToString();
            modelLook.Text = modelServis.GetEntity(c => c.Id == modelId).ModelAdi;
            kategoriLook.Text = kategoriServis.GetEntity(c => c.Id == kategoriId).KategoriAdi;
            baslikTxt.Text = gridView4.GetFocusedRowCellValue("TasitBaslik").ToString();
            kilometreTxt.Text = gridView4.GetFocusedRowCellValue("Kilometre").ToString();
        }
        private void HasarKayitPageLoad()
        {
            hasarGridControl.DataSource = from x in hasarKayitServis.GetEntities(null)
                                          select new
                                          {
                                              x.Id,
                                              x.Tarih,
                                              x.Parca,
                                              x.Masraf,
                                              x.Aciklama,
                                              x.TasitId
                                          };

            tasitLookUpEd.Properties.DataSource = from x in aracServis.GetEntities(null)
                                                  select new
                                                  {
                                                      TasitId = x.Id,
                                                      TasitPlaka = x.Plaka
                                                  };

            id = -1;
            tarihTxt.Text = "";
            masrafTxt.Text = "";
            hasarParcasiTxt.Text = "";
            hasarAciklamaTxt.Text = "";
            tasitLookUpEd.Text = "";
        }

        private void HasarVt_Click(object sender, EventArgs e)
        {
            SimpleButton buton = (SimpleButton)sender;
            switch (buton.Text)
            {
                case "Ekle":
                    try
                    {
                        hasarKayitServis.Add(new HasarKayit
                        {
                            Tarih = DateTime.Parse(tarihTxt.Text.ToString()),
                            Masraf = decimal.Parse(masrafTxt.Text.ToString()),
                            Parca = hasarParcasiTxt.Text.ToString(),
                            Aciklama = hasarAciklamaTxt.Text.ToString(),
                            TasitId = int.Parse(tasitLookUpEd.EditValue.ToString())
                        });
                        MessageBox.Show("Hasar kaydı başarıyla oluşturuldu.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HasarKayitPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Güncelle":
                    try
                    {
                        hasarKayitServis.Update(new HasarKayit
                        {
                            Id = id,
                            Tarih = DateTime.Parse(tarihTxt.Text.ToString()),
                            Masraf = decimal.Parse(masrafTxt.Text.ToString()),
                            Parca = hasarParcasiTxt.Text.ToString(),
                            Aciklama = hasarAciklamaTxt.Text.ToString(),
                            TasitId = int.Parse(tasitLookUpEd.EditValue.ToString())
                        });
                        MessageBox.Show("Hasar kaydı başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HasarKayitPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Sil":
                    try
                    {
                        hasarKayitServis.Delete(new HasarKayit
                        {
                            Id = id
                        });
                        MessageBox.Show("Hasar kaydı başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HasarKayitPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void HasarKayitGrid_Click(object sender, EventArgs e)
        {

            int tasitId = int.Parse(gridView5.GetFocusedRowCellValue("TasitId").ToString());

            id = int.Parse(gridView5.GetFocusedRowCellValue("Id").ToString());
            tarihTxt.Text = gridView5.GetFocusedRowCellValue("Tarih").ToString();
            masrafTxt.Text = gridView5.GetFocusedRowCellValue("Masraf").ToString();
            hasarParcasiTxt.Text = gridView5.GetFocusedRowCellValue("Parca").ToString();
            hasarAciklamaTxt.Text = gridView5.GetFocusedRowCellValue("Aciklama").ToString();
            tasitLookUpEd.Text = aracServis.GetEntity(c => c.Id == tasitId).Plaka;
        }

        private void YorumGrid_Click(object sender, EventArgs e)
        {
            
            int tasitId = int.Parse(gridView6.GetFocusedRowCellValue("TasitId").ToString());

            id = int.Parse(gridView6.GetFocusedRowCellValue("Id").ToString());
            yorumAdTxt.Text = gridView6.GetFocusedRowCellValue("Ad").ToString();
            yorumSoyadTxt.Text = gridView6.GetFocusedRowCellValue("Soyad").ToString();
            yorumMailTxt.Text = gridView6.GetFocusedRowCellValue("Mail").ToString();
            yorumIcerikTxt.Text = gridView6.GetFocusedRowCellValue("Icerik").ToString();
            yorumAracLook.Text = aracServis.GetEntity(c => c.Id == tasitId).TasitBaslik;
        }

        private void YorumVtBtns_Click(object sender, EventArgs e)
        {
            SimpleButton buton = (SimpleButton)sender;
            switch (buton.Text)
            {
                case "Ekle":
                    try
                    {
                        yorumServis.Add(new Yorum
                        {
                            Ad = yorumAdTxt.Text.ToString(),
                            Soyad = yorumSoyadTxt.Text.ToString(),
                            Mail = yorumMailTxt.Text.ToString(),
                            Icerik = yorumIcerikTxt.Text.ToString(),
                            TasitId = int.Parse(yorumAracLook.EditValue.ToString())
                        });
                        MessageBox.Show("Yorum başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        YorumPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Güncelle":
                    try
                    {
                        yorumServis.Update(new Yorum
                        {
                            Id = id,
                            Ad = yorumAdTxt.Text.ToString(),
                            Soyad = yorumSoyadTxt.Text.ToString(),
                            Mail = yorumMailTxt.Text.ToString(),
                            Icerik = yorumIcerikTxt.Text.ToString(),
                            TasitId = int.Parse(yorumAracLook.EditValue.ToString())
                        });
                        MessageBox.Show("Yorum başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        YorumPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Sil":
                    try
                    {
                        yorumServis.Delete(new Yorum
                        {
                            Id = id
                        });
                        MessageBox.Show("Yorum başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        YorumPageLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void fotoKaydetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string yol = Path.GetDirectoryName(Application.ExecutablePath) + @"\..\..\..\";
                DirectoryInfo dir = new DirectoryInfo(yol);
                //string fullPath = dir.FullName + @"Galeri.WebUI\Content\Img\";

                string fullPath = @"E:\derscalismalarim\GitHub Ornek Gelistirme Klasoru\Galeri\Galeri.WebUI\Content\Img\";

                var p = new DirectoryInfo(@"C:\Users\Acer\Desktop\fotolar").GetFiles("*.*");

                foreach (FileInfo dosya in p)
                {
                    dosya.CopyTo(fullPath + dosya.Name);
                }


                fotografServis.Add(new Fotograf
                {
                    FotografAdi = p11,
                    TasitId = int.Parse(fotoTasitLookUp.EditValue.ToString())
                });
                fotografServis.Add(new Fotograf
                {
                    FotografAdi = p22,
                    TasitId = int.Parse(fotoTasitLookUp.EditValue.ToString())
                });
                fotografServis.Add(new Fotograf
                {
                    FotografAdi = p33,
                    TasitId = int.Parse(fotoTasitLookUp.EditValue.ToString())
                });
                fotografServis.Add(new Fotograf
                {
                    FotografAdi = p44,
                    TasitId = int.Parse(fotoTasitLookUp.EditValue.ToString())
                });
                MessageBox.Show("Fotoğraflar başarıyla kaydedildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                YorumPageLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata meydana geldi. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void YorumPageLoad()
        {
            yorumGridControl.DataSource = from x in yorumServis.GetEntities(null)
                                          select new
                                          {
                                              x.Id,
                                              x.Ad,
                                              x.Soyad,
                                              x.Mail,
                                              x.Icerik,
                                              x.TasitId
                                          };

            yorumAracLook.Properties.DataSource = from x in aracServis.GetEntities(null)
                                                  select new
                                                  {
                                                      TasitId = x.Id,
                                                      TasitBaslik = x.TasitBaslik
                                                  };

            id = -1;
            yorumAdTxt.Text = "";
            yorumSoyadTxt.Text = "";
            yorumMailTxt.Text = "";
            yorumIcerikTxt.Text = "";
            tasitLookUpEd.Text = "";
        }
        private void FotografPageLoad()
        {
            fotoTasitLookUp.Properties.DataSource = from x in aracServis.GetEntities(null)
                                                    select new
                                                    {
                                                        TasitPlaka = x.Plaka,
                                                        TasitId = x.Id
                                                    };
            id = -1;
        }

        private void FotoBtns_Click(object sender, EventArgs e)
        {
            SimpleButton buton = (SimpleButton)sender;
            switch (buton.Name)
            {
                case "foto1Btn":
                    if(openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        p1 = openFileDialog1.FileName;
                        p1Plc.Text = p1;
                        p11 = Path.GetFileName(p1);
                        
                        
                    }
                    break;
                case "foto2Btn":
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        p2 = openFileDialog1.FileName;
                        p2Plc.Text = p2;
                        p22 = Path.GetFileName(p2);
                    }
                    break;
                case "foto3Btn":
                    if (openFileDialog3.ShowDialog() == DialogResult.OK)
                    {
                        p3 = openFileDialog3.FileName;
                        p3Plc.Text = p3;
                        p33 = Path.GetFileName(p3);
                    }
                    break;
                case "foto4Btn":
                    if (openFileDialog4.ShowDialog() == DialogResult.OK)
                    {
                        p4 = openFileDialog4.FileName;
                        p4Plc.Text = p4;
                        p44 = Path.GetFileName(p4);
                    }
                    break;
            }
        }
    }
}
