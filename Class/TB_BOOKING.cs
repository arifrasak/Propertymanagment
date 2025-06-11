using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Class
{
    public class TB_BOOKING
    {
        private Guid Id;
        private int PropertyId;
        private Guid UserId;
        private DateTime BookingDate;
        private BookingTypes.BookingStatus Status;

        [Key]
        public Guid ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public int PROPERTYID
        {
            get { return PropertyId; }
            set { PropertyId = value; }
        }
        public Guid USERID
        {
            get { return UserId; }
            set { UserId = value; }
        }
        public DateTime BOOKINGDATE
        {
            get { return BookingDate; }
            set { BookingDate = value; }
        }
        public BookingTypes.BookingStatus STATUS
        {
            get { return Status; }
            set { Status = value; }
        }
    }
}
