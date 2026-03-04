using System;
using System.Collections.Generic;

namespace WpfApp6.Models;

public partial class Товар
{
    public string Артикул { get; set; } = null!;

    public string НаименованиеТовара { get; set; } = null!;

    public string ЕдиницаИзмерения { get; set; } = null!;

    public string Цена { get; set; } = null!;

    public string Поставщик { get; set; } = null!;

    public string Производитель { get; set; } = null!;

    public string КатегорияТовара { get; set; } = null!;

    public string ДействующаяСкидка { get; set; } = null!;

    public string Количество { get; set; } = null!;

    public string Описание { get; set; } = null!;

    public string? Фото { get; set; }

    public virtual ICollection<Заказ> Заказs { get; set; } = new List<Заказ>();
}
