using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Utils.EMailUtils
{
    public class Recipient
    {
        #region Public Properties

        /// <summary>
        /// The email address of this recipient.
        /// </summary>
        public string Address = null;

        /// <summary>
        /// The display name of this recipient.
        /// </summary>
        public string DisplayName = null;

        /// <summary>
        /// How the recipient will receive this message (To, CC, BCC).
        /// </summary>
        public MapiMailMessage.RecipientType RecipientType = MapiMailMessage.RecipientType.To;

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Creates a new recipient with the specified address.
        /// </summary>
        public Recipient(string address)
        {
            Address = address;
        }

        /// <summary>
        /// Creates a new recipient with the specified address and display name.
        /// </summary>
        public Recipient(string address, string displayName)
        {
            Address = address;
            DisplayName = displayName;
        }

        /// <summary>
        /// Creates a new recipient with the specified address and recipient type.
        /// </summary>
        public Recipient(string address, MapiMailMessage.RecipientType recipientType)
        {
            Address = address;
            RecipientType = recipientType;
        }

        /// <summary>
        /// Creates a new recipient with the specified address, display name and recipient type.
        /// </summary>
        public Recipient(string address, string displayName, MapiMailMessage.RecipientType recipientType)
        {
            Address = address;
            DisplayName = displayName;
            RecipientType = recipientType;
        }

        #endregion Constructors

        #region Internal Methods

        /// <summary>
        /// Returns an interop representation of a recepient.
        /// </summary>
        /// <returns></returns>
        internal MapiMailMessage.MAPIHelperInterop.MapiRecipDesc GetInteropRepresentation()
        {
            MapiMailMessage.MAPIHelperInterop.MapiRecipDesc interop = new MapiMailMessage.MAPIHelperInterop.MapiRecipDesc();

            if (DisplayName == null)
            {
                interop.Name = Address;
            }
            else
            {
                interop.Name = DisplayName;
                interop.Address = Address;
            }

            interop.RecipientClass = (int)RecipientType;

            return interop;
        }

        #endregion Internal Methods
    }
}
