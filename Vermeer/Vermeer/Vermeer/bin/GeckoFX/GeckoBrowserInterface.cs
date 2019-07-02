﻿using System;
using System.Windows.Forms;
using Gecko;
using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;

namespace Vermeer.Vermeer.bin.GeckoFX
{
    public class GeckoBrowserInterface : VermeerBrowserInterface
    {
        public event EventHandler<DocumentTitleChange> OnTitleChange;
        public event EventHandler<DocumentURLChange> OnDocumentURLChange;
        public event EventHandler<DocumentIconChange> OnDocumentIconChange;
        public event EventHandler<DocumentLoadingChange> OnDocumentLoadChange;


        #region Vars

        GeckoWebBrowser webBrowser;
        MaterialTabPage hostTabPage;

        #endregion

        #region CreateBrowserHandle

        public void CreateBrowserHandle(string URL, MaterialTabPage tabPage)
        {
            //Initialize firefox Xpcom
            Xpcom.Initialize("Firefox64");

            //Initialize the web browser comp
            webBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
            webBrowser.Navigate(URL);

            //GeckoPreferences
            Gecko.GeckoPreferences.User["general.useragent.override"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) Gecko/20081201 Firefox/60.0";

        }

        #endregion CreateBrowserHandle

        #region GetBrowserControl

        public Control GetBrowserControl()
        { return webBrowser; }

        #endregion GetBrowserControl

        #region GetTabPage

        public MaterialTabPage getTabPage()
        { return hostTabPage; }

        #endregion GetTabPage

        #region GoBack

        public void GoBack()
        { if (webBrowser.CanGoBack) webBrowser.GoBack(); }

        #endregion GoBack

        #region GoForward

        public void GoForward()
        { if (webBrowser.CanGoForward) webBrowser.GoForward(); }

        #endregion GoForward

        #region IsBackEnabled

        public bool IsBackEnabled()
        { return webBrowser.CanGoBack; }

        #endregion IsBackEnabled

        #region IsForwardEnabled

        public bool IsForwardAvailable()
        { return webBrowser.CanGoForward; }

        #endregion IsForwardEnabled

        #region WebBrowserNavigate

        public void Navigate(string URL)
        { webBrowser.Navigate(URL); }

        #endregion WebBrowserNagivate

        #region On Initialization

        public void OnInit(MaterialTabPage page, string StartURL, string ProxyURI)
        {
            //Sets the host tab page
            hostTabPage = page;

            CreateBrowserHandle(StartURL, page);
            
            if (ProxyURI != null) { vermeer.ApplicationLogger.AddToLog("WARN", "Vermeer currently doesn't support GeckoFX proxy support!"); }
        }

        #endregion On Initialization

        #region Reload

        public void Reload()
        {
            webBrowser.Reload();
        }

        #endregion Reload

        #region SetProxyConnection

        public void SetProxyConnection(string ProxyURI)
        {
            
        }

        #endregion SetProxyConnection

    }
}
