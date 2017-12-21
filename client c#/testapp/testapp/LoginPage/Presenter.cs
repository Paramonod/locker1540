using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testapp.BL;

namespace testapp
{
    class Presenter
    {
        private readonly IMainForm _view;
        private readonly IAuth _auth;
        private readonly IMessageService _messageService;

        public Presenter(IMainForm view, IAuth auth, IMessageService service)
        {
            _view = view;
            _auth = auth;
            _messageService = service;
            _view.auth += _view_auth;
        }

        private void _view_auth(object sender, EventArgs e)
        {
            string login = _view.login;
            string passwd = _view.passwd;
            if (_auth.auth(login, passwd))
            {
                _messageService.ShowMessage("YEP");
                AppN.endLogin();
            } else
            {
                _messageService.ShowMessage("Nope");
            }
        }
    }
}
