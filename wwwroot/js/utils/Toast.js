// type: success, info, warning, error
var ToastMessage = (() => {
  function show({ type = "info", title = "", message = "", duration = 3000 }) {
    var toastContainer = document.getElementById("toast-container");
    if (toastContainer) {
      var toastItem = document.createElement("div");

      const delay = (duration / 1000).toFixed(2);

      toastItem.classList.add("toast-item");
      toastItem.classList.add(`toast-${type}`);
      toastItem.style.animation = `slideInLeft ease .3s, fadeOut linear 1s ${delay}s forwards;`;

      var toastContent = `
                          <div class="toast-icon">
                          </div>
                          <div class="toast-body">
                              <h3 class="toast-title" style="red">${title}</h3>
                              <p class="toast-msg">${message}</p>
                          </div>
                          <div class="toast-close">
                              X
                          </div>
                      `;

      toastItem.insertAdjacentHTML("beforeend", toastContent);
      toastContainer.appendChild(toastItem);

      const autoRemoveId = setTimeout(function () {
        toastContainer.removeChild(toastItem);
      }, duration + 1000);

      toastItem.onclick = function (e) {
        if (e.target.closest(".toast-close")) {
          toastContainer.removeChild(toastItem);
          clearTimeout(autoRemoveId);
        }
      };
    }
  }

  return {
    show: show,
  };
})();
