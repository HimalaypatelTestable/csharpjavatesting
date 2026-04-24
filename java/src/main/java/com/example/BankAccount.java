package com.example;

public class BankAccount {

    private final String accountNumber;
    private final String owner;
    private double balance;

    public BankAccount(String accountNumber, String owner, double openingBalance) {
        if (openingBalance < 0) {
            throw new IllegalArgumentException("opening balance must be non-negative");
        }
        this.accountNumber = accountNumber;
        this.owner = owner;
        this.balance = openingBalance;
    }

    public void deposit(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException("deposit must be positive");
        }
        balance += amount;
    }

    public void withdraw(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException("withdrawal must be positive");
        }
        if (amount > balance) {
            throw new IllegalStateException("insufficient funds");
        }
        balance -= amount;
    }

    public double getBalance() {
        return balance;
    }

    public String getOwner() {
        return owner;
    }

    public String getAccountNumber() {
        return accountNumber;
    }

    @Override
    public String toString() {
        return String.format("BankAccount{%s, owner=%s, balance=%.2f}", accountNumber, owner, balance);
    }
}
