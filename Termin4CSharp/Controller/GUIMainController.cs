﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View;

namespace Termin4CSharp.Controller {

    public class GUIMainController : IController {

        public GUIMain GUIMain { get; set; }


        public GUIMainController(GUIMain guiMain) {
            this.GUIMain = guiMain;
            this.GUIMain.Controller = this;
        }

        public void LoadRooms() {
            DAL dal = new DAL();
            var rooms = dal.Get(new Room()).Cast<Room>().ToList();
            this.GUIMain.SetRooms(rooms);
        }

        public void NotifyExceptionToView() {
            throw new NotImplementedException();
        }
    }
}