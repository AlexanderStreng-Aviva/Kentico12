//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types.MedioClinic;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(LandingPage.CLASS_NAME, typeof(LandingPage))]

namespace CMS.DocumentEngine.Types.MedioClinic
{
	/// <summary>
	/// Represents a content item of type LandingPage.
	/// </summary>
	public partial class LandingPage : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "MedioClinic.LandingPage";


		/// <summary>
		/// The instance of the class that provides extended API for working with LandingPage fields.
		/// </summary>
		private readonly LandingPageFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// LandingPageID.
		/// </summary>
		[DatabaseIDField]
		public int LandingPageID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("LandingPageID"), 0);
			}
			set
			{
				SetValue("LandingPageID", value);
			}
		}


		/// <summary>
		/// Landing page name.
		/// </summary>
		[DatabaseField]
		public string LandingPageName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("LandingPageName"), @"");
			}
			set
			{
				SetValue("LandingPageName", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with LandingPage fields.
		/// </summary>
		[RegisterProperty]
		public LandingPageFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with LandingPage fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class LandingPageFields : AbstractHierarchicalObject<LandingPageFields>
		{
			/// <summary>
			/// The content item of type LandingPage that is a target of the extended API.
			/// </summary>
			private readonly LandingPage mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="LandingPageFields" /> class with the specified content item of type LandingPage.
			/// </summary>
			/// <param name="instance">The content item of type LandingPage that is a target of the extended API.</param>
			public LandingPageFields(LandingPage instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// LandingPageID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.LandingPageID;
				}
				set
				{
					mInstance.LandingPageID = value;
				}
			}


			/// <summary>
			/// Landing page name.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.LandingPageName;
				}
				set
				{
					mInstance.LandingPageName = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="LandingPage" /> class.
		/// </summary>
		public LandingPage() : base(CLASS_NAME)
		{
			mFields = new LandingPageFields(this);
		}

		#endregion
	}
}