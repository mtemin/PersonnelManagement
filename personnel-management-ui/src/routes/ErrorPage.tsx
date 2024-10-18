import { useRouteError } from "react-router-dom";
import { Button } from "@/components/ui/button"


export default function ErrorPage() {
  const error: any = useRouteError();
  console.error(error);

  return (
    <main id="error-page" className="bg-red-800 rounded py-8 px-16 mx-auto w-[30rem] mt-[20%] translate-y-[-50%]">
      <h1 className="font-bold text-3xl mb-6">Error!</h1>
      <p className="mb-6">No page found with this url.</p>
      <p className="mb-6">
          Error :
          <i> {error.statusText || error.message}</i>
      </p>
      <Button>
        <a href='/'>
          Go back to homepage
        </a>
      </Button>

    </main>
  );
}
