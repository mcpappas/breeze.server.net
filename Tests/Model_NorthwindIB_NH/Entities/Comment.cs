namespace Models.NorthwindIB.NH
{
    using System;
    using System.Collections.Generic;

    public partial class Comment
    {
        public virtual System.DateTime CreatedOn { get; set; }
        public virtual string Comment1 { get; set; }
        public virtual byte SeqNum { get; set; }

        //public virtual ICollection<ProductComment> ProductComments { get; set; }

        // Need to override for composite keys
        public override int GetHashCode()
        {
            if (SeqNum == 0) return base.GetHashCode(); //transient instance
            return CreatedOn.GetHashCode() ^ SeqNum.GetHashCode();

        }

        // Need to override for composite keys
        public override bool Equals(object obj)
        {
            var x = obj as Comment;
            if (x == null) return false;
            if (SeqNum == 0 && x.SeqNum == 0) return ReferenceEquals(this, x);
            return (CreatedOn == x.CreatedOn) && (SeqNum == x.SeqNum);

        }

    }

/*    public partial class ProductComment
    {
        public virtual Product Product { get; set; }
        public virtual Comment Comment { get; set; }

        public virtual string Text { get; set; }
        public virtual System.DateTime CreatedOn { get; set; }
        public virtual byte SeqNum { get; set; }
        public virtual int ProductID { get; set; }

        // Need to override for composite keys
        public override int GetHashCode()
        {
            if (SeqNum == 0) return base.GetHashCode(); //transient instance
            return CreatedOn.GetHashCode() ^ SeqNum.GetHashCode() ^ ProductID.GetHashCode();

        }

        // Need to override for composite keys
        public override bool Equals(object obj)
        {
            var x = obj as ProductComment;
            if (x == null) return false;
            if (SeqNum == 0 && x.SeqNum == 0) return ReferenceEquals(this, x);
            return (CreatedOn == x.CreatedOn) && (SeqNum == x.SeqNum) && (ProductID == x.ProductID);

        }

    }*/
}
