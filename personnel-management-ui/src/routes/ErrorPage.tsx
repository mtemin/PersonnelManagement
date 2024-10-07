import { useRouteError } from "react-router-dom";
import { Button } from "@/components/ui/button"


export default function ErrorPage() {
  const error: any = useRouteError();
  console.error(error);

  return (
    <div id="error-page" className="bg-red-800 rounded p-8 mx-auto w-[25rem] mt-[25%] translate-y-[-50%]">
      <h1 className="font-bold text-3xl mb-3">Error!</h1>
      <p className="mb-3">No page found with this url.</p>
      <p className="mb-3">
        <i>{error.statusText || error.message}</i>
      </p>
      <Button>
        <a href='/'>
          Go back to homepage
        </a>
      </Button>

    </div>
  );
}