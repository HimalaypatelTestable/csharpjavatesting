(function () {
    "use strict";

    const LANGUAGES = ["Java", "C#", "JavaScript", "HTML", "CSS"];

    function initCounter() {
        const counterEl = document.getElementById("counter");
        const incBtn = document.getElementById("increment-btn");
        const resetBtn = document.getElementById("reset-btn");
        let count = 0;

        function render() {
            counterEl.textContent = String(count);
        }

        incBtn.addEventListener("click", function () {
            count += 1;
            render();
        });

        resetBtn.addEventListener("click", function () {
            count = 0;
            render();
        });

        render();
    }

    function initLangList() {
        const list = document.getElementById("lang-list");
        LANGUAGES.forEach(function (name) {
            const li = document.createElement("li");
            li.textContent = name;
            list.appendChild(li);
        });
    }

    function initEcho() {
        const input = document.getElementById("echo-input");
        const output = document.getElementById("echo-output");
        input.addEventListener("input", function () {
            output.textContent = input.value.split("").reverse().join("");
        });
    }

    document.addEventListener("DOMContentLoaded", function () {
        initCounter();
        initLangList();
        initEcho();
    });
})();
