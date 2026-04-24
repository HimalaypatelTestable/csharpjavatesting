package com.example;

public class Main {
    public static void main(String[] args) {
        System.out.println("Mixed-Language Demo :: Java side");

        Calculator calc = new Calculator();
        System.out.println("2 + 3 = " + calc.add(2, 3));
        System.out.println("10 * 7 = " + calc.multiply(10, 7));
        System.out.println("fact(6) = " + calc.factorial(6));

        System.out.println("reverse('hello world') = " + StringUtils.reverse("hello world"));
        System.out.println("palindrome('racecar') = " + StringUtils.isPalindrome("racecar"));

        BankAccount acct = new BankAccount("A-001", "Alice", 100.00);
        acct.deposit(50.25);
        acct.withdraw(30.00);
        System.out.println(acct);
    }
}
