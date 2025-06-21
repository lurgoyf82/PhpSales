<?php
declare(strict_types=1);

namespace src\Entities;
class Item
{
    public string $itemType;
    public string $name;
    public float $price;
    public float $taxes;
    public float $taxedPrice;
    public float $taxPercentage;
    public int $quantity;
    public bool $imported;
}
