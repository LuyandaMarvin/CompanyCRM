using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MyCRM.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Lead")]
    [DefaultProperty("FullName")]
    [Appearance("ActiveContact", Criteria = "Active = true", TargetItems = "*", FontStyle = System.Drawing.FontStyle.Bold)]
    public class CompanyContact : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CompanyContact(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Active = true;
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { SetPropertyValue<string>(nameof(FirstName), ref _FirstName, value); }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { SetPropertyValue<string>(nameof(LastName), ref _LastName, value); }
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string FullName
        {
            get
            {
                return ObjectFormatter.Format("{FirstName} {LastName}", this,
                    EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
            }
        }

        private string _PhoneNumber;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { SetPropertyValue<string>(nameof(PhoneNumber), ref _PhoneNumber, value); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }

        private Company _Company;
        [Association]
        public Company Company
        {
            get { return _Company; }
            set { SetPropertyValue<Company>(nameof(Company), ref _Company, value); }
        }

        private bool _Active;
        [ImmediatePostData]
        public bool Active
        {
            get { return _Active; }
            set { SetPropertyValue<bool>(nameof(Active), ref _Active, value); }
        }
    }
}