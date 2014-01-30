﻿using System.Collections;
using System.Collections.Generic;
using Csla;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Magenic.BadgeApplication.Common.DTO;
using Magenic.BadgeApplication.Common.Enums;
using Magenic.BadgeApplication.Common.Interfaces;
using System;

namespace Magenic.BadgeApplication.BusinessLogic.PointsReport
{
    [Serializable]
    public sealed class PointsReportItem : BusinessBase<PointsReportItem>, IPointsReportItem
    {
        #region Properties

        private bool   PaidOut;
        private IList<int> BadgeAwardIds;
        private int? PayoutById;
        private DateTime? PayoutDate;

        public static readonly PropertyInfo<int> EmployeeIdProperty = RegisterProperty<int>(c => c.EmployeeId);
        public int EmployeeId
        {
            get { return GetProperty(EmployeeIdProperty); }
            private set { SetProperty(EmployeeIdProperty, value); }
        }

        public static readonly PropertyInfo<string> EmployeeADNameProperty = RegisterProperty<string>(c => c.EmployeeADName);
        public string EmployeeADName
        {
            get { return GetProperty(EmployeeADNameProperty); }
            private set { SetProperty(EmployeeADNameProperty, value); }
        }

        public static readonly PropertyInfo<int> TotalPointsProperty = RegisterProperty<int>(c => c.TotalPoints);
        public int TotalPoints
        {
            get { return GetProperty(TotalPointsProperty); }
            private set { SetProperty(TotalPointsProperty, value); }
        }

        #endregion Properties

        #region Methods

        public static readonly MethodInfo PayoutMethod = RegisterMethod(typeof(PointsReportItem), "Payout");

        public void Payout(int employeeId, DateTime payoutDate)
        {
            if (CanExecuteMethod(PayoutMethod))
            {
                this.PaidOut = true;
                this.PayoutById = employeeId;
                this.PayoutDate = payoutDate;
            }
        }

        #endregion Methods

        #region Rules

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
            
            this.BusinessRules.AddRule(new IsInRole(AuthorizationActions.ExecuteMethod, PayoutMethod, PermissionType.Administrator.ToString()));            
        }

        #endregion Rules

        internal PointsReportItemDTO Unload()
        {
            using (this.BypassPropertyChecks)
            {
                var returnValue = new PointsReportItemDTO
                {
                    EmployeeId = this.EmployeeId,
                    EmployeeADName = this.EmployeeADName,
                    TotalPoints = this.TotalPoints,
                    PaidOut = this.PaidOut,
                    PayoutById = this.PayoutById,
                    PayoutDate = this.PayoutDate,
                    BadgeAwardIds = this.BadgeAwardIds
                };
                return returnValue;
            }
        }

        internal void Load(PointsReportItemDTO data)
        {
            using (this.BypassPropertyChecks)
            {
                this.EmployeeId = data.EmployeeId;
                this.EmployeeADName = data.EmployeeADName;
                this.TotalPoints = data.TotalPoints;
                this.PaidOut = false;
                this.PayoutById = null;
                this.PayoutDate = null;
                this.BadgeAwardIds = data.BadgeAwardIds;
            }
            this.MarkClean();
            this.MarkOld();
            this.MarkAsChild();
        }

    }
}