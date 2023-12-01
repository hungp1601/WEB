window.addEventListener("load", () => {
  fetchDepartmentByUser();
});

const renderCard = (department) => {
  const image =
    department.images && department.images.length
      ? department.images[0].path
      : "";

  return `<div class="card" id="department-${
    department.id
  }"><img src="/images/departments/${image}" />
    <div class="detail">
        <span>Địa chỉ: ${department.address}</span>
        <span>Diện tích: ${department.acreage}m2</span>
        <span>Giá phòng trọ: ${department.price}</span>
        <span>Thời gian đăng: ${formatDate(department.createdAt)}</span>
    </div>
    </div>`;
};

const fetchDepartmentByUser = () => {
  CustomRequest.get({
    url: `/Department/Me`,
    addToken: true,
    callback: (response) => {
      const departments = JSON.parse(response);
      appendViewDepartment(departments);
    },
    failCallBack: (request) => {
      console.log(request);
    },
  });
};

const appendViewDepartment = (departments) => {
  const listCard = document.querySelector(".list-card");
  if (!departments.length) return;

  departments.forEach((department) => {
    const parser = new DOMParser();
    const htmlDoc = parser.parseFromString(renderCard(department), "text/html");
    const newCard = htmlDoc.querySelector(".card");
    listCard.appendChild(newCard);

    newCard.addEventListener("click", () => {
      window.location.href = "/Department/Detail/" + department.id;
    });
  });
};

function formatDate(dateString) {
  var date = new Date(dateString);
  return date.toLocaleDateString("vi-VN");
}
