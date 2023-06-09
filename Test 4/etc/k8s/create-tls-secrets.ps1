mkcert `
"test4-st-authserver" `
"test4-st-angular" `
"test4-st-public-web" `
"test4-st-gateway-web" "test4-st-gateway-web-public" `
"test4-st-identity" "test4-st-administration" "test4-st-saas" "test4-st-product" 
kubectl create namespace test4
kubectl create secret tls -n test4 test4-tls --cert=./test4-st-authserver+8.pem  --key=./test4-st-authserver+8-key.pem