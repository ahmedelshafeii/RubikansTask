namespace API.DTOs
{
    public class ItemDTO
    {
        public int ItemSerial { get; set; }

        public string ItemArName { get; set; }
        public string ItemEnName { get; set; }
        public string Notes { get; set; }
        public float Price { get; set; }
        public float Vat { get; set; }
    }
}
