//------------------Request------------------------
function Check_new_Request() {
    ajaxCall("GET", "../../api/Request/CountNEWRequest?Agent_ID=" + Agent_ID, "", successCountNEWRequest, errorCountNEWRequest)
}
function successCountNEWRequest(data) {
    var count = data.length / 2;
    var strNewRequest;
    if (count) {
        document.getElementById("newRequest").style.display = "block";
        document.getElementById("newRequest").innerHTML = count;
        strNewRequest = `<div style="float:right;"><p class="mb-0 font-weight-normal float-left dropdown-header">בקשות חדשות</p></div>`;
        for (var i = 0; i < data.length; i += 2) {
            strNewRequest += `<a id="dropdown_Status_item" class="dropdown-item" data-name="${data[i].AttractionName}">
                                                             <div class="item-thumbnail">
                                                                   <div class="item-icon bg-primary">
                                                                      <i class="ti-info mx-0"></i>
                                                                    </div>
                                                              </div>
                                                               <div class="item-content">
                                                                       <h6 class="att_name_item font-weight-normal">${data[i].AttractionName}</h6 >
                                                                         <p class="font-weight-light small-text mb-0 text-muted"> ${data[i + 1].FirstName} ${data[i + 1].SureName}
                                                                         </p>
                                                               </div></a >`;
        }
        document.getElementById("NewReqMenu").innerHTML = strNewRequest;
        return;
    }
    document.getElementById("newRequest").style.display = "none";
}
function errorCountNEWRequest(err) {
    alert("errorCountNEWRequest");
}

//------------------message------------------------
function Check_new_message() {
    ajaxCall("GET", "../../api/badge/NEWMessage?Agent_ID=" + Agent_ID, "", successGETNEWmessage, errorGETNEWmessage)
}
$(document).on('click', '.dropdown-item', function () {
    var customerID = this.getAttribute("data-id");
    console.log(customerID);
    ajaxCall("PUT", "../../api/badge/ReadMessage?customerID=" + customerID, "", successReadMessage, errorReadMessage)
});
function successReadMessage(id) {
    if (id != 0) {
        console.log("נקרא");
        console.log(id);
        sessionStorage.setItem("customerID_chat", id);
        window.location.href = "../Chat/chat.html";
    }
    else alert("error");
}
function errorReadMessage() {
    alert("errorReadMessage");
}
function successGETNEWmessage(data) {
    console.log(data);
    var str = "";
    if (data.length) {
        document.getElementById("newMesseages_point").style.display = "block";
        for (k of data) {
            str += `<a id="dropdown_chat_item" class="dropdown-item"  data-id="${k.Id}">
                    <div class="item-thumbnail">
                        <img src="${k.Img}" alt="image" class="profile-pic">
                                </div>
                        <div class="item-content flex-grow">
                            <h6 class="ellipsis font-weight-normal">${k.FirstName} ${k.SureName}</h6>
                            <p class="font-weight-light small-text text-muted mb-0">
                                The meeting is cancelled
                                    </p>
                        </div>
                         </a>`;
        }
        document.getElementById("NEWmessage").innerHTML = str;
        return;
    }
    document.getElementById("newMesseages_point").style.display = "none";
}
function errorGETNEWmessage() {
    alert("errorGETNEWmessage");
}
