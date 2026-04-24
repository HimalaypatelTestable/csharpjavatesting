package com.example;

public final class StringUtils {

    private StringUtils() {}

    public static String reverse(String input) {
        if (input == null) return null;
        return new StringBuilder(input).reverse().toString();
    }

    public static boolean isPalindrome(String input) {
        if (input == null) return false;
        String cleaned = input.toLowerCase().replaceAll("[^a-z0-9]", "");
        return cleaned.equals(reverse(cleaned));
    }

    public static int countWords(String input) {
        if (input == null || input.isBlank()) return 0;
        return input.trim().split("\\s+").length;
    }
}
