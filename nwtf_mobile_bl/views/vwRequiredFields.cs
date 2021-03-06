﻿using SQLite;
using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class views
    {
        public class vwRequiredFields
        {
            [PrimaryKey, NotNull]
            public Guid id { get; set; }
            [NotNull]
            public String requiredFieldName { get; set; }
            [NotNull]
            public int requiredFieldType { get; set; }

            public static List<views.vwRequiredFields> getRequiredFields()
            {
                return dataservices.requiredFields.GetRequiredFields();
            }
        }
    }
}
