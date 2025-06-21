<?php
namespace src\Entities;

class Cart
{
    private array $items = [];
    private float $total = 0.0;
    private float $tax = 0.0;

    public function addItem(Item $item): void
    {
        $this->items[] = $item;
        $this->calculate();
    }

    public function getItems(): array
    {
        return $this->items;
    }

    public function getTotal(): float {
        return $this->total;
    }

    public function getTax(): float {
        return $this->tax;
    }

    public function editItem(int $index, Item $item): void
    {
        try {
            if (isset($this->items[$index])) {
                $this->items[$index] = $item;
                $this->calculate();
            }
        } catch (\Exception $e) {
            // Handle exception if needed
            echo "Cart.php editItem: " . $e->getMessage();
        }
    }

    public function removeItem(int $index): void
    {
        try {
            if (isset($this->items[$index])) {
                unset($this->items[$index]);
                $this->calculate();
            }
        } catch (\Exception $e) {
            // Handle exception if needed
            echo "Cart.php removeItem: " . $e->getMessage();
        }
    }

    private function calculate() : void
    {
        $this->total = 0.0;
        $this->tax = 0.0;

        foreach ($this->items as $item) {
            $this->total = $this->total + $item->taxedPrice;
            $this->tax += $item->taxes;
        }
    }
}
