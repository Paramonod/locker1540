using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using testapp.BL;
using testapp.UsersPage;

namespace testapp
{
    public static class AppN
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);

             Form1 form = new Form1();
             MessageService service = new MessageService();
             authTest auth = new authTest();

             Presenter presenter = new Presenter(form, auth, service);
             Application.Run(form);*/
            startLogin();
        }
        public static void startLogin()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

        Form1 form = new Form1();
        MessageService service = new MessageService();
        authTest auth = new authTest();

        Presenter presenter = new Presenter(form, auth, service);
        Application.Run(form);
        }
        internal static void endLogin()
        {

            UsersForm form2 = new UsersForm();
            //MessageService service1 = new MessageService();
            //authTest auth1 = new authTest();

            //Presenter presenter = new Presenter(form2, auth1, service1);
            form2.Show();
        }
    }
}
